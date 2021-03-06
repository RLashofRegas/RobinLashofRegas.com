import { Component, Input } from '@angular/core';
import { TopicTile } from './topic-tile';
import {
  trigger,
  state,
  style,
  animate,
  transition,
  animateChild,
  query
} from '@angular/animations';

const hoveredState = 'hovered';
const notHoveredState = 'notHovered';
const fadeInTime = 200; // in ms
const fadeOutTime = 100; // in ms

@Component({
  selector: 'app-topic-tile',
  templateUrl: './topic-tile.component.html',
  styleUrls: ['./topic-tile.component.css'],
  animations: [
    trigger('tileHover', [
      transition(notHoveredState + ' <=> ' + hoveredState, [
        query('@imgAnimation, @titleAnimation', [
          animateChild()
        ])
      ])
    ]),
    trigger('imgAnimation', [
      state(notHoveredState, style({
        opacity: 1.0
      })),
      state(hoveredState, style({
        opacity: 0.8
      })),
      transition(notHoveredState + ' => ' + hoveredState, [
        animate(fadeInTime)
      ]),
      transition(hoveredState + ' => ' + notHoveredState, [
        animate(fadeOutTime)
      ])
    ]),
    trigger('titleAnimation', [
      state(notHoveredState, style({
        'font-size': '50px'
      })),
      state(hoveredState, style({
        'font-size': '60px'
      })),
      transition(notHoveredState + ' => ' + hoveredState, [
        animate(fadeInTime)
      ]),
      transition(hoveredState + ' => ' + notHoveredState, [
        animate(fadeOutTime)
      ])
    ])
  ]
})
export class TopicTileComponent {

  @Input() tile: TopicTile;
  hoverState: string = notHoveredState;

  tileHover(): void {
    this.hoverState = this.hoverState === notHoveredState ? hoveredState : notHoveredState;
  }

}
