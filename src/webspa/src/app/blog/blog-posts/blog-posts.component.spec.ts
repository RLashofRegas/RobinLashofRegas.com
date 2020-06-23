import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogPostsComponent } from './blog-posts.component';

describe('BlogPostsComponent', () => {
  let component: BlogPostsComponent;
  let fixture: ComponentFixture<BlogPostsComponent>;

  beforeEach(async(() => {
    void TestBed.configureTestingModule({
      declarations: [ BlogPostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    void expect(component).toBeTruthy();
  });
});
