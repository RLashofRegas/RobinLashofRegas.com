import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, Subject } from 'rxjs';
import { shareReplay } from 'rxjs/operators';

import { BlogServicesModule } from './blog-services.module';
import { AppOptions } from 'src/app/shared/models/app-options.model';
import { OptionsService } from 'src/app/shared/services/options.service';
import { IBlog } from '../models/blog.model';
import { IPost } from '../models/post.model';

@Injectable({
  providedIn: BlogServicesModule
})
export class BlogService {
  private appOptions: Observable<AppOptions>;

  constructor(private optionsService: OptionsService, private http: HttpClient) {
    this.appOptions = optionsService.options().pipe(shareReplay(1));
  }

  getBlogs(): Observable<IBlog[]> {
    const blogsSubject = new Subject<IBlog[]>();
    this.appOptions.subscribe(
      (options) => {
        const url = options.blogAPIUrl + '/Blogs';
        this.http
          .get<IBlog[]>(url)
          .subscribe(
            (blogs) => {
              for (const blog of blogs) {
                blog.tileImagePath = options.blogAPIUrl + blog.tileImagePath;
              }
              blogsSubject.next(blogs);
            }
          );
      }
    );
    return blogsSubject.asObservable();
  }

  postBlog(blogData: FormData): Observable<IBlog> {
    const postBlogSubject = new Subject<IBlog>();
    this.appOptions.subscribe(
      (options) => {
        const url = options.blogAPIUrl + '/Blogs';
        this.http
          .post(url, blogData)
          .subscribe(
            (blog: IBlog) => {
              postBlogSubject.next(blog);
            }
          );
      }
    );
    return postBlogSubject.asObservable();
  }

  getPosts(): Observable<IPost[]> {
    const postsSubject = new Subject<IPost[]>();
    this.appOptions.subscribe(
      (options) => {
        const url = options.blogAPIUrl + '/Posts';
        this.http
          .get<IPost[]>(url)
          .subscribe(
            (posts) => {
              postsSubject.next(posts);
            }
          );
      }
    );
    return postsSubject.asObservable();
  }

  addPost(postData: FormData): Observable<IPost> {
    const addPostSubject = new Subject<IPost>();
    this.appOptions.subscribe(
      (options) => {
        const url = options.blogAPIUrl + '/Posts';
        this.http
          .post(url, postData)
          .subscribe(
            (post: IPost) => {
              addPostSubject.next(post);
            }
          );
      }
    );
    return addPostSubject.asObservable();
  }
}
