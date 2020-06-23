import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBlogComponent } from './new-blog.component';

describe('NewBlogComponent', () => {
  let component: NewBlogComponent;
  let fixture: ComponentFixture<NewBlogComponent>;

  beforeEach(async(() => {
    void TestBed.configureTestingModule({
      declarations: [ NewBlogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewBlogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    void expect(component).toBeTruthy();
  });
});
