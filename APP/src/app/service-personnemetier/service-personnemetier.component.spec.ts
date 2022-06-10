import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicePersonnemetierComponent } from './service-personnemetier.component';

describe('ServicePersonnemetierComponent', () => {
  let component: ServicePersonnemetierComponent;
  let fixture: ComponentFixture<ServicePersonnemetierComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicePersonnemetierComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicePersonnemetierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
