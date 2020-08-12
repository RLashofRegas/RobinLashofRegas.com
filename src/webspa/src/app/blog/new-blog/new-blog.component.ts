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
  newBlogForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private blogService: BlogService) { }

  ngOnInit(): void {
    this.newBlogForm = this.formBuilder.group({
      blogName: new FormControl(null),
      tileImage: new FormControl(null)
    });
  }

  // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types, @typescript-eslint/no-explicit-any
  onSubmit(blogData: any): void {
    const submitData: FormData = new FormData();
    // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    submitData.append('Name', blogData.blogName);
    submitData.append('TileImage', this.selectedFile);

    this.blogService.postBlog(submitData);
    this.newBlogForm.reset();
  }

  onSelectFile(selectEvent: Event): void {
    this.selectedFile = (selectEvent.target as HTMLInputElement).files[0];
  }

}
