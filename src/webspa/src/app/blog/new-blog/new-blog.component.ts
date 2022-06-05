import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, UntypedFormControl } from '@angular/forms';
import { BlogService } from '../blog-services/blog.service';

@Component({
  selector: 'app-new-blog',
  templateUrl: './new-blog.component.html',
  styleUrls: ['./new-blog.component.css']
})
export class NewBlogComponent implements OnInit {
  selectedFile: File = null;
  newBlogForm: UntypedFormGroup;

  constructor(private formBuilder: UntypedFormBuilder, private blogService: BlogService) { }

  ngOnInit(): void {
    this.newBlogForm = this.formBuilder.group({
      name: new UntypedFormControl(''),
      tileImage: new UntypedFormControl('')
    });
  }

  // eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types, @typescript-eslint/no-explicit-any
  onSubmit(blogData: any): void {
    const submitData: FormData = new FormData();
    // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    submitData.append('name', blogData.name);
    submitData.append('tileImage', this.selectedFile);

    this.blogService.postBlog(submitData);
    this.newBlogForm.reset();
  }

  onSelectFile(selectEvent: Event): void {
    this.selectedFile = (selectEvent.target as HTMLInputElement).files[0];
  }

}
