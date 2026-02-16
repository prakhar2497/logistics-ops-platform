import { Injectable } from '@angular/core';
import { HttpBase } from './http-base';
import { BrowserStorage } from './browser-storage';
import { tap, shareReplay } from 'rxjs';
import { Observable } from 'rxjs';
import { ReferenceData as ReferenceDataModel } from '../../shared/model/reference-data.model';

@Injectable({
  providedIn: 'root',
})
export class ReferenceData {
  private referenceData$: Observable<ReferenceDataModel[]> | null = null;
  private readonly STORAGE_KEY = 'referenceData';

  constructor(
    private http: HttpBase,
    private browserStorage: BrowserStorage,
  ) {}

  // Load reference data, cache it in memory and storage
  loadAndCacheReferenceData(): Observable<ReferenceDataModel[]> {
    if (!this.referenceData$) {
      this.referenceData$ = this.http
        .get<ReferenceDataModel[]>('ReferenceData/GetAllReferenceData')
        .pipe(
          tap((data) => {
            // Save to localStorage for persistence across sessions
            this.browserStorage.save(this.STORAGE_KEY, data);
          }),
          shareReplay(1), // Cache the result in memory
        );
    }
    return this.referenceData$;
  }

  // Get cached reference data from memory or storage
  getCachedReferenceData(): ReferenceDataModel[] | null {
    // Try to get from storage (persisted)
    return this.browserStorage.getJson<ReferenceDataModel[]>(this.STORAGE_KEY);
  }

  // GET all reference data (original method for backward compatibility)
  getReferenceData() {
    return this.http.get<ReferenceDataModel[]>(
      'ReferenceData/GetAllReferenceData',
    );
  }
}
