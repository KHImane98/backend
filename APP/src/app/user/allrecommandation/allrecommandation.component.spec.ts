import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllrecommandationComponent } from './allrecommandation.component';

describe('AllrecommandationComponent', () => {
  let component: AllrecommandationComponent;
  let fixture: ComponentFixture<AllrecommandationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllrecommandationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllrecommandationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
