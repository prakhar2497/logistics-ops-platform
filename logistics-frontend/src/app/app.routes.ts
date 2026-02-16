import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./features/auth/auth.routes').then((m) => m.AUTH_ROUTES),
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./features/dashboard/dashboard.routes').then(
        (m) => m.DASHBOARD_ROUTES,
      ),
    canActivate: [authGuard],
  },
  {
    path: 'vehicles',
    loadChildren: () =>
      import('./features/vehicles/vehicles.routes').then(
        (m) => m.VEHICLES_ROUTES,
      ),
    // canActivate: [authGuard],
  },
  {
    path: 'deliveries',
    loadChildren: () =>
      import('./features/deliveries/deliveries.routes').then(
        (m) => m.DELIVERIES_ROUTES,
      ),
    canActivate: [authGuard],
  },
];
