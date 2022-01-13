import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GalleryPTComponent } from './gallery-pt.component';

describe('GalleryPTComponent', () => {
  let component: GalleryPTComponent;
  let fixture: ComponentFixture<GalleryPTComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GalleryPTComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GalleryPTComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
