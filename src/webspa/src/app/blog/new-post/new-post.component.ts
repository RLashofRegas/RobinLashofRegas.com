import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

import { BlogService } from "../blog-services/blog.service";
import { IBlog } from "../models/blog.model";

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css']
})
export class NewPostComponent implements OnInit {
  blogs: IBlog[];
  newPostForm: FormGroup;

  constructor(private blogService: BlogService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.blogService
      .getBlogs()
      .subscribe(
        (blogs) => {
          this.blogs = blogs;
        }
      );

    this.newPostForm = this.formBuilder
      .group({
        blogId: new FormControl(null),
        title: new FormControl(null),
        rawContent: new FormControl(null),
        parsedContent: new FormControl(null)
      });
  }

  // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types, @typescript-eslint/no-explicit-any
  onSubmit(postData: any): void {
    // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    console.log(postData.blogId)
    // const submitData: FormData = new FormData();
    // // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    // submitData.append('BlogId', postData.blogId);
    // // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    // submitData.append('Title', postData.title);
    // // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    // submitData.append('RawContent', postData.rawContent);
    // // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    // submitData.append('ParsedContent', postData.parsedContent);

    // this.blogService.addPost(submitData);
    this.newPostForm.reset();
  }

}
