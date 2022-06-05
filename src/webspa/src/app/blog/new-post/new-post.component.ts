import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormControl } from '@angular/forms';

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
  newPostForm: UntypedFormGroup;

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
    this.blogService
      .getBlogs()
      .subscribe(
        (blogs) => {
          this.blogs = blogs;
        }
      );

    this.newPostForm = new UntypedFormGroup({
      blogId: new UntypedFormControl(''),
      title: new UntypedFormControl(''),
      rawContent: new UntypedFormControl(''),
      parsedContent: new UntypedFormControl('')
    });
  }

  onSubmit(formData: IPost): void {
    this.blogService.addPost(formData);
    this.newPostForm.reset();
  }

}
