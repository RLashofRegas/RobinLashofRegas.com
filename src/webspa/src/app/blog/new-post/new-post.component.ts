import { Component, OnInit } from '@angular/core';

import { BlogService } from "../blog-services/blog.service";
import { IBlog } from "../models/blog.model";

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  private blogs: IBlog[];

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
    this.blogService
      .getBlogs()
      .subscribe(
        (blogs) => {
          this.blogs = blogs;
          console.log(blogs);
        }
      );
  }

}
