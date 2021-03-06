import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { TopicTile } from './topic-tile/topic-tile';
import { BlogService } from '../blog-services/blog.service';

@Component({
  selector: 'app-topic-tiles',
  templateUrl: './topic-tiles.component.html',
  styleUrls: ['./topic-tiles.component.css']
})
export class TopicTilesComponent implements OnInit {

  tiles: Observable<TopicTile[]>;

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
    this.tiles = this.blogService
      .getBlogs()
      .pipe(
        map(
          blogs =>
            blogs.map(
              blog => {
                console.log(blog.tileImagePath);
                return new TopicTile(blog.name, blog.name, blog.tileImagePath, '');
              }
            )
        )
      );
  }

}
