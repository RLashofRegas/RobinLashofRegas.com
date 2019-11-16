import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { IAppOptions } from "../models/app-options.model";
import { WINDOW } from "../providers/window.provider";

@Injectable({
  providedIn: 'root'
})
export class OptionsService {

  constructor(@Inject(WINDOW) private window: Window, private http: HttpClient) { }

  options(): Observable<IAppOptions> {
    console.log(this.window.location.origin);
    let url = '/Options';
    
    return this.http.get<IAppOptions>(url);
  }
}
