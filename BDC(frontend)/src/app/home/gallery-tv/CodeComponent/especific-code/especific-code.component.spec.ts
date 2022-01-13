import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EspecificCodeComponent } from './especific-code.component';

describe('EspecificCodeComponent', () => {
  let component: EspecificCodeComponent;
  let fixture: ComponentFixture<EspecificCodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EspecificCodeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EspecificCodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
