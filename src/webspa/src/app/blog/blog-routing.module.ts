import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BlogDashboardComponent } from "./blog-dashboard/blog-dashboard.component";
import { NewPostComponent } from "./new-post/new-post.component";
import { NewBlogComponent } from './new-blog/new-blog.component';

const routes: Routes = [
  {
    path: 'new-post',
    component: NewPostComponent
  },
  {
    path: 'new-blog',
    component: NewBlogComponent
  },
  {
    path: '',
    component: BlogDashboardComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class BlogRoutingModule { }
