import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { BlogService } from "../blog-services/blog.service";
import { IBlog } from "../models/blog.model";
import { IPost } from "../models/post.model"

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  blogs: IBlog[];
  newPostForm: FormGroup;

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
    this.blogService
      .getBlogs()
      .subscribe(
        (blogs) => {
          this.blogs = blogs;
        }
      );

    this.newPostForm = new FormGroup({
      blogId: new FormControl(''),
      title: new FormControl(''),
      rawContent: new FormControl(''),
      parsedContent: new FormControl('')
    });
  }

  onSubmit(formData: IPost): void {
    console.log(formData)

    // this.blogService.addPost(submitData);
    this.newPostForm.reset();
  }

}
