import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { BrowserStorage } from '../services/browser-storage';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const browserStorageService = inject(BrowserStorage);
  const token = browserStorageService.get('authToken');

  if (token) {
    const authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
    return next(authReq);
  }

  return next(req);
};
