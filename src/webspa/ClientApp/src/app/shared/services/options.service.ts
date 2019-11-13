import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Subject, Subscriber } from 'rxjs';

import { IAppOptions } from "../models/app-options.model";
import { WINDOW } from "../providers/window.provider";

@Injectable({
  providedIn: 'root'
})
export class OptionsService {
  appOptions: IAppOptions;

  private optionsLoadedSource = new Subject<IAppOptions>();
  optionsLoaded$ = this.optionsLoadedSource.asObservable();
  isReady: boolean = false;

  constructor(@Inject(WINDOW) private window: Window, private http: HttpClient) { }

  loadOptions(): void {
    console.log(this.window.location.origin);
    let url = '/Options';
    
    this.http.get<IAppOptions>(url).subscribe((response : IAppOptions) => {
      console.log('App Options Loaded.');
      this.appOptions = response;
      this.isReady = true;
      this.optionsLoadedSource.next();
    });
  }
}
