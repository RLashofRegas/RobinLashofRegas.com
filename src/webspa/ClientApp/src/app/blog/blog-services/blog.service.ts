import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, Subject } from 'rxjs';
import { shareReplay } from "rxjs/operators";

import { BlogServicesModule } from "./blog-services.module";
import { IAppOptions } from 'src/app/shared/models/app-options.model';
import { OptionsService } from 'src/app/shared/services/options.service';
import { IBlog } from "../models/blog.model";

@Injectable({
  providedIn: BlogServicesModule
})
export class BlogService {
  private appOptions: Observable<IAppOptions>

  constructor(private optionsService: OptionsService, private http: HttpClient) { 
    this.appOptions = optionsService.options().pipe(shareReplay(1))
  }

  getBlogs(): Observable<IBlog[]> {
    let blogsSubject = new Subject<IBlog[]>();
    this.appOptions.subscribe(
      (options) => {
        let url = options.blogAPIUrl + "/Blogs";
        this.http
          .get<IBlog[]>(url)
          .subscribe(
            (blogs) => {
              blogsSubject.next(blogs)
            }
          );
      }
    );
    return blogsSubject.asObservable();
  }
}
