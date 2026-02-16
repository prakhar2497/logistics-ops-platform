import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import {
  FormControl,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { merge, startWith } from 'rxjs';
import { Auth } from '../../../core/services/auth';
import { BrowserStorage } from '../../../core/services/browser-storage';
import { ReferenceData } from '../../../core/services/reference-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
  ],
  templateUrl: './login.html',
  styleUrl: './login.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Login {
  readonly email = new FormControl('', [Validators.required, Validators.email]);
  readonly password = new FormControl('', [
    Validators.required,
    Validators.minLength(6),
  ]);
  emailErrorMessageSignal = signal('');
  passwordErrorMessageSignal = signal('');

  emailRules = [
    { key: 'required', message: 'Email is required' },
    { key: 'email', message: 'Not a valid email' },
  ];

  passwordRules = [
    { key: 'required', message: 'Password is required' },
    { key: 'minlength', message: 'Password must be at least 8 characters' },
  ];

  constructor(
    private authservice: Auth,
    private browserStorage: BrowserStorage,
    private referenceDataService: ReferenceData,
    private router: Router,
  ) {
    this.registerControl(
      this.email,
      this.emailErrorMessageSignal,
      this.emailRules,
    );
    this.registerControl(
      this.password,
      this.passwordErrorMessageSignal,
      this.passwordRules,
    );
  }
  private startControlSubscription(control: FormControl, updateFn: () => void) {
    merge(
      control.statusChanges.pipe(startWith(control.status)),
      control.valueChanges.pipe(startWith(control.value)),
    )
      .pipe(takeUntilDestroyed())
      .subscribe(() => updateFn());
  }

  configureValidation(
    control: FormControl,
    messageSignal: any,
    rules: { key: string; message: string }[],
  ) {
    for (const rule of rules) {
      if (control.hasError(rule.key)) {
        messageSignal.set(rule.message);
        return;
      }
    }
    messageSignal.set('');
  }

  private registerControl(
    control: FormControl,
    messageSignal: any,
    rules: { key: string; message: string }[],
  ) {
    this.startControlSubscription(control, () =>
      this.configureValidation(control, messageSignal, rules),
    );
    this.configureValidation(control, messageSignal, rules);
  }

  hide = signal(true);
  clickEvent(event: MouseEvent) {
    this.hide.set(!this.hide());
    event.stopPropagation();
  }

  onSubmit() {
    var email = this.email.value;
    var password = this.password.value;
    this.authservice.login(email!, password!).subscribe((res) => {
      this.browserStorage.save('authToken', res.token);
      this.loadReferenceData();
    });
  }

  private loadReferenceData() {
    this.referenceDataService.loadAndCacheReferenceData().subscribe(
      () => {
        // Reference data loaded and cached successfully
        this.router.navigate(['/dashboard']);
      },
      (error) => {
        console.error('Error fetching reference data:', error);
        // Navigate to dashboard even if reference data fetch fails
        this.router.navigate(['/dashboard']);
      },
    );
  }
}
