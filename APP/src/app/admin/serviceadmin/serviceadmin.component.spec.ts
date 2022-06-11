import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceadminComponent } from './serviceadmin.component';

describe('ServiceadminComponent', () => {
  let component: ServiceadminComponent;
  let fixture: ComponentFixture<ServiceadminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServiceadminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceadminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
