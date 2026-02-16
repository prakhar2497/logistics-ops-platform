import { Routes } from '@angular/router';
import { VehicleList } from './vehicle-list/vehicle-list';

export const VEHICLES_ROUTES: Routes = [
  {
    path: '',
    component: VehicleList,
  },
];
