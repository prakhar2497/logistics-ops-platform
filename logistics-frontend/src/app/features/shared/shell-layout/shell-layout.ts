import { Component, signal } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-shell-layout',
  imports: [
    CommonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    RouterLink,
    RouterOutlet,
  ],
  templateUrl: './shell-layout.html',
  styleUrl: './shell-layout.css',
  standalone: true,
})
export class ShellLayout {
  isSidenavOpen = signal(true);

  toggleSidenav(): void {
    this.isSidenavOpen.update((value) => !value);
  }

  closeSidenav(): void {
    this.isSidenavOpen.set(false);
  }
}
