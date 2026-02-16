import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialog } from '@angular/material/dialog';
import { Vehicle } from '../../../core/services/vehicle';
import { VehicleModel } from '../model/vehicle.model';
import { ReferenceData } from '../../../core/services/reference-data';
import { ReferenceData as ReferenceDataModel } from '../../../shared/model/reference-data.model';
import { VehicleFormDialogComponent } from '../vehicle-form-dialog/vehicle-form-dialog';

@Component({
  selector: 'app-vehicle-list',
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
  ],
  templateUrl: './vehicle-list.html',
  styleUrl: './vehicle-list.css',
})
export class VehicleList implements OnInit {
  vehicles: VehicleModel[] = [];
  displayedColumns: string[] = [
    'registrationNumber',
    'type',
    'capacityInKg',
    'status',
    'lastServiceDate',
    'actions',
  ];
  isLoading = false;
  errorMessage = '';
  typeOptions: ReferenceDataModel[] = [];
  statusOptions: ReferenceDataModel[] = [];
  private statusReferenceData: Map<string, ReferenceDataModel> = new Map();
  private typeReferenceData: Map<string, ReferenceDataModel> = new Map();

  constructor(
    private vehicleService: Vehicle,
    private referenceDataService: ReferenceData,
    private dialog: MatDialog,
  ) {}

  ngOnInit() {
    this.loadReferenceData();
    this.loadVehicles();
  }

  private loadReferenceData() {
    const cachedData = this.referenceDataService.getCachedReferenceData();
    if (cachedData) {
      this.statusOptions = cachedData
        .filter((item) => item.category === 'VehicleStatus')
        .sort((a, b) => a.sortOrder - b.sortOrder);
      this.typeOptions = cachedData
        .filter((item) => item.category === 'VehicleType')
        .sort((a, b) => a.sortOrder - b.sortOrder);

      this.statusReferenceData = new Map(
        this.statusOptions.map((item) => [item.id, item]),
      );
      this.typeReferenceData = new Map(
        this.typeOptions.map((item) => [item.id, item]),
      );
    }
  }

  // Get display name for status from reference data
  getStatusDisplayName(statusCode: string): string {
    const statusRef = this.statusReferenceData.get(statusCode);
    return statusRef ? statusRef.displayName : statusCode;
  }

  // Get display name for type from reference data
  getTypeDisplayName(typeCode: string): string {
    const typeRef = this.typeReferenceData.get(typeCode);
    return typeRef ? typeRef.displayName : typeCode;
  }

  loadVehicles() {
    this.isLoading = true;
    this.errorMessage = '';
    this.vehicleService.getVehicleList().subscribe({
      next: (data) => {
        this.vehicles = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Failed to load vehicles';
        console.error('Error loading vehicles:', err);
        this.isLoading = false;
      },
    });
  }

  openCreateVehicleDialog() {
    this.openVehicleFormDialog();
  }

  deleteVehicle(id: string) {
    if (confirm('Are you sure you want to delete this vehicle?')) {
      this.vehicleService.deleteVehicle(id).subscribe({
        next: () => {
          this.vehicles = this.vehicles.filter((v) => v.id !== id);
        },
        error: (err) => {
          this.errorMessage = 'Failed to delete vehicle';
          console.error('Error deleting vehicle:', err);
        },
      });
    }
  }

  editVehicle(vehicle: VehicleModel) {
    this.openVehicleFormDialog(vehicle);
  }

  private openVehicleFormDialog(vehicle?: VehicleModel) {
    const dialogRef = this.dialog.open(VehicleFormDialogComponent, {
      width: '520px',
      data: {
        vehicle,
        typeOptions: this.typeOptions,
        statusOptions: this.statusOptions,
      },
    });

    dialogRef.afterClosed().subscribe((result: VehicleModel | undefined) => {
      if (!result) {
        return;
      }

      const request$ = vehicle
        ? this.vehicleService.updateVehicle(vehicle.id, result)
        : this.vehicleService.createVehicle(result);

      request$.subscribe({
        next: () => {
          this.loadVehicles();
        },
        error: (err) => {
          this.errorMessage = vehicle
            ? 'Failed to update vehicle'
            : 'Failed to create vehicle';
          console.error('Error saving vehicle:', err);
        },
      });
    });
  }
}
