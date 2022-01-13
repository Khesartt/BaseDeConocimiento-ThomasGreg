import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GalleryGDComponent } from './gallery-gd.component';

describe('GalleryGDComponent', () => {
  let component: GalleryGDComponent;
  let fixture: ComponentFixture<GalleryGDComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GalleryGDComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GalleryGDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
