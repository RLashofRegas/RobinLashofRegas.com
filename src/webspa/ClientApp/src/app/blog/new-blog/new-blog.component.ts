import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { BlogService } from '../blog-services/blog.service';

@Component({
  selector: 'app-new-blog',
  templateUrl: './new-blog.component.html',
  styleUrls: ['./new-blog.component.css']
})
export class NewBlogComponent implements OnInit {
  private newBlogForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private blogService: BlogService) { }

  ngOnInit() {
    this.newBlogForm = this.formBuilder.group({
      blogName: new FormControl(null),
      tileImage: new FormControl(null)
    });
  }

  onSubmit(blogData: FormData) {
    console.log('new blog has been submitted.', blogData);
    this.blogService.postBlog(blogData);
    this.newBlogForm.reset();
  }

}
