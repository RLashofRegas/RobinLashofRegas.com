import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';

import { AppOptions } from '../models/app-options.model';
import { environment } from './../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class OptionsService {

  options(): Observable<AppOptions> {
    const opts: AppOptions = { blogAPIUrl: environment.blogAPIUrl }
    return of(opts)
  }
}
