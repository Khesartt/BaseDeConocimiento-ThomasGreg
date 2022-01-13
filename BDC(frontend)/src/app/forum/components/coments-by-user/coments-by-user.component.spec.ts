import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComentsByUserComponent } from './coments-by-user.component';

describe('ComentsByUserComponent', () => {
  let component: ComentsByUserComponent;
  let fixture: ComponentFixture<ComentsByUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComentsByUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComentsByUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
