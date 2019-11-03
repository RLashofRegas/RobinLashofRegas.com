import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { TopicTilesComponent } from './topic-tiles/topic-tiles.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { TopicTileComponent } from './topic-tiles/topic-tile/topic-tile.component';
import { BlogPostsComponent } from './blog-posts/blog-posts.component';


@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    TopicTilesComponent,
    TopicTileComponent,
    BlogPostsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatGridListModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
