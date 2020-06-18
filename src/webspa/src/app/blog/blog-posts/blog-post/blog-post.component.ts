import { Component, Input } from '@angular/core';
import { IPost } from '../../models/post.model';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.css']
})
export class BlogPostComponent {

  @Input() post: IPost;
}
