import { Component, OnInit } from '@angular/core';

import { OptionsService } from "./shared/services/options.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'webspa';

  constructor(private optionsService: OptionsService) { }

  ngOnInit(): void {
    this.optionsService.loadOptions();
  }
}
