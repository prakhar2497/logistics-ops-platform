import { Injectable } from '@angular/core';
import { HttpBase } from './http-base';
import { VehicleModel } from '../../features/vehicles/model/vehicle.model';

@Injectable({
  providedIn: 'root',
})
export class Vehicle {
  constructor(private http: HttpBase) {}

  // GET all vehicles
  getVehicleList() {
    return this.http.get<VehicleModel[]>('vehicle/GetVehicles');
  }

  // GET vehicle by ID
  getVehicleById(id: string) {
    return this.http.get<VehicleModel>(`vehicles/${id}`);
  }

  // CREATE new vehicle
  createVehicle(vehicle: VehicleModel) {
    return this.http.post<VehicleModel>('vehicle/CreateVehicle', vehicle);
  }

  // UPDATE vehicle
  updateVehicle(id: string, vehicle: VehicleModel) {
    return this.http.put<VehicleModel>(`vehicle/UpdateVehicle/${id}`, vehicle);
  }

  // DELETE vehicle
  deleteVehicle(id: string) {
    return this.http.delete<void>(`vehicle/DeleteVehicle/${id}`);
  }
}
