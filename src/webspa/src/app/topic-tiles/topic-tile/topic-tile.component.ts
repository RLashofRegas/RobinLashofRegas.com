import { Component, OnInit, Input } from '@angular/core';
import { TopicTile } from './topic-tile';

@Component({
  selector: 'app-topic-tile',
  templateUrl: './topic-tile.component.html',
  styleUrls: ['./topic-tile.component.css']
})
export class TopicTileComponent implements OnInit {

  @Input() tile: TopicTile;

  constructor() { }

  ngOnInit() {
  }

}
