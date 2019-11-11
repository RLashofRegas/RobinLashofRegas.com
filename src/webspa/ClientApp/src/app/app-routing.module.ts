import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlogDashboardComponent } from './blog/blog-dashboard/blog-dashboard.component';
import { NewPostComponent } from './blog/new-post/new-post.component';


const routes: Routes = [
  { path: 'new-post', component: NewPostComponent },
  { path: '**', component: BlogDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
