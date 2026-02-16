import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BrowserStorage {
  save(key: string, data: any): void {
    try {
      const serializedData =
        typeof data === 'string' ? data : JSON.stringify(data);
      var existingStorage = this.get(key);
      if (existingStorage !== null || existingStorage !== undefined) {
        this.delete(key);
      }
      localStorage.setItem(key, serializedData);
    } catch (error) {
      console.error(
        `Error saving data to localStorage for key "${key}":`,
        error,
      );
    }
  }

  get(key: string): string | null {
    try {
      return localStorage.getItem(key);
    } catch (error) {
      console.error(
        `Error retrieving data from localStorage for key "${key}":`,
        error,
      );
      return null;
    }
  }

  getJson<T>(key: string): T | null {
    try {
      const data = localStorage.getItem(key);
      return data ? JSON.parse(data) : null;
    } catch (error) {
      console.error(
        `Error retrieving/parsing JSON from localStorage for key "${key}":`,
        error,
      );
      return null;
    }
  }

  delete(key: string): void {
    try {
      localStorage.removeItem(key);
    } catch (error) {
      console.error(
        `Error deleting data from localStorage for key "${key}":`,
        error,
      );
    }
  }

  clear(): void {
    try {
      localStorage.clear();
    } catch (error) {
      console.error('Error clearing localStorage:', error);
    }
  }

  saveSession(key: string, data: any): void {
    try {
      const serializedData =
        typeof data === 'string' ? data : JSON.stringify(data);
      sessionStorage.setItem(key, serializedData);
    } catch (error) {
      console.error(
        `Error saving data to sessionStorage for key "${key}":`,
        error,
      );
    }
  }

  getSession(key: string): string | null {
    try {
      return sessionStorage.getItem(key);
    } catch (error) {
      console.error(
        `Error retrieving data from sessionStorage for key "${key}":`,
        error,
      );
      return null;
    }
  }

  getSessionJson<T>(key: string): T | null {
    try {
      const data = sessionStorage.getItem(key);
      return data ? JSON.parse(data) : null;
    } catch (error) {
      console.error(
        `Error retrieving/parsing JSON from sessionStorage for key "${key}":`,
        error,
      );
      return null;
    }
  }

  deleteSession(key: string): void {
    try {
      sessionStorage.removeItem(key);
    } catch (error) {
      console.error(
        `Error deleting data from sessionStorage for key "${key}":`,
        error,
      );
    }
  }

  clearSession(): void {
    try {
      sessionStorage.clear();
    } catch (error) {
      console.error('Error clearing sessionStorage:', error);
    }
  }
}
