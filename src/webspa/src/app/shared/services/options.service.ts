import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';

import { AppOptions } from '../models/app-options.model';
import { environment } from './../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class OptionsService {

  constructor() { }

  options(): Observable<AppOptions> {
    let opts: AppOptions = { blogAPIUrl: environment.blogAPIUrl }
    return of(opts)
  }
}
