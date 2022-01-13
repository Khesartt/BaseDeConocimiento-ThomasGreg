import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditionsComponent } from './additions.component';

describe('AdditionsComponent', () => {
  let component: AdditionsComponent;
  let fixture: ComponentFixture<AdditionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
