import { Component, OnInit } from '@angular/core';
import { tiles } from './topic-tiles';
import { TopicTile } from './topic-tile/topic-tile';

@Component({
  selector: 'app-topic-tiles',
  templateUrl: './topic-tiles.component.html',
  styleUrls: ['./topic-tiles.component.css']
})
export class TopicTilesComponent implements OnInit {

  tiles: TopicTile[] = tiles;

  constructor() { }

  ngOnInit() {
  }

}