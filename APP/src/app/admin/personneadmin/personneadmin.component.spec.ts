import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonneadminComponent } from './personneadmin.component';

describe('PersonneadminComponent', () => {
  let component: PersonneadminComponent;
  let fixture: ComponentFixture<PersonneadminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonneadminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonneadminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
