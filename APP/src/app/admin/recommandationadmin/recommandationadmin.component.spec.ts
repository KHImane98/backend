import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommandationadminComponent } from './recommandationadmin.component';

describe('RecommandationadminComponent', () => {
  let component: RecommandationadminComponent;
  let fixture: ComponentFixture<RecommandationadminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecommandationadminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecommandationadminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
