import { Component, OnInit } from '@angular/core';
import { BlogService } from '../blog-services/blog.service';
import { Observable } from 'rxjs';
import { IPost } from '../models/post.model';

@Component({
  selector: 'app-blog-posts',
  templateUrl: './blog-posts.component.html',
  styleUrls: ['./blog-posts.component.css']
})
export class BlogPostsComponent implements OnInit {

  posts: Observable<IPost[]>;

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
    this.posts = this.blogService
      .getPosts();
  }

}
