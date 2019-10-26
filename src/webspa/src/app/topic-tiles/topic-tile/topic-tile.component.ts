import { Component, OnInit, Input } from '@angular/core';
import { TopicTile } from './topic-tile';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations'

const hoveredState: string = 'hovered';
const notHoveredState: string = 'notHovered'

@Component({
  selector: 'app-topic-tile',
  templateUrl: './topic-tile.component.html',
  styleUrls: ['./topic-tile.component.css'],
  animations: [
    trigger('tileHover', [
      state(notHoveredState, style({
        opacity: 1.0
      })),
      state(hoveredState, style({
        opacity: 0.7
      })),
      transition(notHoveredState + ' => ' + hoveredState, [
        animate('0.5s')
      ]),
      transition(hoveredState + ' => ' + notHoveredState, [
        animate('0.25s')
      ])
    ])
  ]
})
export class TopicTileComponent implements OnInit {

  @Input() tile: TopicTile;
  hoverState: string = notHoveredState;

  constructor() { }

  ngOnInit() {
  }

  tileHover(): void {
    this.hoverState = this.hoverState === notHoveredState ? hoveredState : notHoveredState;
    console.log("changed state to " + this.hoverState);
  }

}
