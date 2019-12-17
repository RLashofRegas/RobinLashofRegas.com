import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { BlogService } from '../blog-services/blog.service';

@Component({
  selector: 'app-new-blog',
  templateUrl: './new-blog.component.html',
  styleUrls: ['./new-blog.component.css']
})
export class NewBlogComponent implements OnInit {
  selectedFile: File = null;
  private newBlogForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private blogService: BlogService) { }

  ngOnInit() {
    this.newBlogForm = this.formBuilder.group({
      blogName: new FormControl(null),
      tileImage: new FormControl(null)
    });
  }

  onSubmit(blogData: any) {
    const submitData: FormData = new FormData();
    submitData.append('Name', blogData.blogName);
    submitData.append('TileImage', this.selectedFile);

    console.log('new blog has been submitted.', blogData);
    this.blogService.postBlog(submitData);
    this.newBlogForm.reset();
  }

  onSelectFile(selectEvent: any) {
    this.selectedFile = <File>selectEvent.target.files[0];
  }

}
