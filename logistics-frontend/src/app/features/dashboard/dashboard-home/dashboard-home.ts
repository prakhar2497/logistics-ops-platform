import { Component } from '@angular/core';
import { ShellLayout } from '../../shared/shell-layout/shell-layout';

@Component({
  selector: 'app-dashboard-home',
  imports: [ShellLayout],
  templateUrl: './dashboard-home.html',
  styleUrl: './dashboard-home.css',
})
export class DashboardHome {
  constructor() {
    console.log('DashboardHome initialized');
  }
}
