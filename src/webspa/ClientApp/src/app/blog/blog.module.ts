import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TopicTilesComponent } from './topic-tiles/topic-tiles.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { TopicTileComponent } from './topic-tiles/topic-tile/topic-tile.component';
import { BlogPostsComponent } from './blog-posts/blog-posts.component';
import { NewPostComponent } from './new-post/new-post.component';
import { BlogDashboardComponent } from './blog-dashboard/blog-dashboard.component';



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
    BrowserAnimationsModule,
    MatGridListModule,
    MatCardModule
  ],
  exports: [
    BlogDashboardComponent
  ]
})
export class BlogModule { }
