import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicTilesComponent } from './topic-tiles.component';

describe('TopicTilesComponent', () => {
  let component: TopicTilesComponent;
  let fixture: ComponentFixture<TopicTilesComponent>;

  beforeEach(async(() => {
    void TestBed.configureTestingModule({
      declarations: [ TopicTilesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopicTilesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    void expect(component).toBeTruthy();
  });
});
