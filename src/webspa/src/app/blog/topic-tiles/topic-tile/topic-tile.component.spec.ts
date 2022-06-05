import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TopicTileComponent } from './topic-tile.component';

describe('TopicTileComponent', () => {
  let component: TopicTileComponent;
  let fixture: ComponentFixture<TopicTileComponent>;

  beforeEach(waitForAsync(() => {
    void TestBed.configureTestingModule({
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
    void expect(component).toBeTruthy();
  });
});
