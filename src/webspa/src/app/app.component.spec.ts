import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  beforeEach(async(() => {
    void TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
    const app = fixture.debugElement.componentInstance;
    void expect(app).toBeTruthy();
  });

  it(`should have as title 'webspa'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
    const app = fixture.debugElement.componentInstance;
    // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access
    void expect(app.title).toEqual('webspa');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
    const compiled = fixture.debugElement.nativeElement;
    // eslint-disable-next-line @typescript-eslint/no-unsafe-member-access, @typescript-eslint/no-unsafe-call
    void expect(compiled.querySelector('.content span').textContent).toContain('webspa app is running!');
  });
});
