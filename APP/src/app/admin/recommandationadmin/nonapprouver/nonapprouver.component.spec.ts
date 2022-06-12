import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NonapprouverComponent } from './nonapprouver.component';

describe('NonapprouverComponent', () => {
  let component: NonapprouverComponent;
  let fixture: ComponentFixture<NonapprouverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NonapprouverComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NonapprouverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
