import { Component, OnInit } from '@angular/core';
import { IAppOptions } from 'src/app/shared/models/app-options.model';
import { OptionsService } from 'src/app/shared/services/options.service';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  private appOptions: IAppOptions;

  constructor(private optionsService: OptionsService) {
    if(this.optionsService.isReady)
    {
      this.appOptions = this.optionsService.appOptions;
    }
    else
    {
      this.optionsService.optionsLoaded$.subscribe(o => this.appOptions = o)
    }
    
    console.log(`Set appOptions in NewPostComponent. BlogUrl is ${this.appOptions.blogAPIUrl}`);
   }

  ngOnInit() {
  }

}
