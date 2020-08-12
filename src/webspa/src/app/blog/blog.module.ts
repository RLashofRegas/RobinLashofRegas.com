import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';

import { BlogRoutingModule } from './blog-routing.module';
import { BlogServicesModule } from './blog-services/blog-services.module';
import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { NewPostComponent } from './new-post/new-post.component';
import { BlogDashboardComponent } from './blog-dashboard/blog-dashboard.component';
import { TopicTileComponent } from './topic-tiles/topic-tile/topic-tile.component';
import { TopicTilesComponent } from './topic-tiles/topic-tiles.component';
import { NewBlogComponent } from './new-blog/new-blog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BlogPostComponent } from './blog-posts/blog-post/blog-post.component';



@NgModule({
  declarations: [
    TopicTilesComponent,
    TopicTileComponent,
    BlogPostsComponent,
    NewPostComponent,
    BlogDashboardComponent,
    NewBlogComponent,
    BlogPostComponent,
  ],
  imports: [
    CommonModule,
    MatGridListModule,
    MatCardModule,
    BlogRoutingModule,
    BlogServicesModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule
  ],
  exports: []
})
export class BlogModule { }
