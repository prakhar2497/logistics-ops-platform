import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
  ValidatorFn,
} from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { VehicleModel } from '../model/vehicle.model';
import { ReferenceData as ReferenceDataModel } from '../../../shared/model/reference-data.model';

export interface VehicleFormDialogData {
  vehicle?: VehicleModel;
  typeOptions: ReferenceDataModel[];
  statusOptions: ReferenceDataModel[];
}

@Component({
  selector: 'app-vehicle-form-dialog',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
  ],
  templateUrl: './vehicle-form-dialog.html',
  styleUrl: './vehicle-form-dialog.css',
})
export class VehicleFormDialogComponent {
  readonly form;

  constructor(
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<VehicleFormDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: VehicleFormDialogData,
  ) {
    this.form = this.formBuilder.nonNullable.group({
      registrationNumber: ['', Validators.required],
      type: ['', Validators.required],
      capacityInKg: [0, [Validators.required, Validators.min(1)]],
      status: ['', Validators.required],
      lastServiceDate: [''],
    });

    if (data.vehicle) {
      const originalLastServiceDate = this.toDateInputValue(
        data.vehicle.lastServiceDate,
      );

      this.form.patchValue({
        registrationNumber: data.vehicle.registrationNumber,
        type: data.vehicle.type,
        capacityInKg: data.vehicle.capacityInKg,
        status: data.vehicle.status,
        lastServiceDate: originalLastServiceDate,
      });

      this.form.controls.lastServiceDate.setValidators([
        Validators.required,
        this.lastServiceDateChangedValidator(originalLastServiceDate),
      ]);
      this.form.controls.lastServiceDate.updateValueAndValidity({
        emitEvent: false,
      });
    }
  }

  private toDateInputValue(date: string | Date): string {
    const parsedDate = new Date(date);
    if (Number.isNaN(parsedDate.getTime())) {
      return '';
    }

    return parsedDate.toISOString().slice(0, 10);
  }

  private lastServiceDateChangedValidator(originalDate: string): ValidatorFn {
    return (control: AbstractControl<string>): ValidationErrors | null => {
      if (!control.value || control.value !== originalDate) {
        return null;
      }

      return { unchangedDate: true };
    };
  }

  submit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const formValue = this.form.getRawValue();
    const updatedLastServiceDate =
      this.data.vehicle && formValue.lastServiceDate
        ? new Date(formValue.lastServiceDate)
        : this.data.vehicle?.lastServiceDate ?? new Date();

    this.dialogRef.close({
      id: this.data.vehicle?.id ?? '',
      registrationNumber: formValue.registrationNumber,
      type: formValue.type,
      capacityInKg: Number(formValue.capacityInKg),
      status: formValue.status,
      lastServiceDate: new Date(updatedLastServiceDate),
    } satisfies VehicleModel);
  }

  cancel() {
    this.dialogRef.close();
  }
}
