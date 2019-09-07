import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicTileComponent } from './topic-tile.component';

describe('TopicTileComponent', () => {
  let component: TopicTileComponent;
  let fixture: ComponentFixture<TopicTileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopicTileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopicTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
