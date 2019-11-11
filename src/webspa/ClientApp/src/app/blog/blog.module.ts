import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';

import { BlogRoutingModule } from "./blog-routing.module";
import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { NewPostComponent } from './new-post/new-post.component';
import { BlogDashboardComponent } from './blog-dashboard/blog-dashboard.component';
import { TopicTileComponent } from './topic-tiles/topic-tile/topic-tile.component';
import { TopicTilesComponent } from './topic-tiles/topic-tiles.component';



@NgModule({
  declarations: [
    TopicTilesComponent,
    TopicTileComponent,
    BlogPostsComponent,
    NewPostComponent,
    BlogDashboardComponent
  ],
  imports: [
    CommonModule,
    MatGridListModule,
    MatCardModule,
    BlogRoutingModule
  ],
  exports: []
})
export class BlogModule { }