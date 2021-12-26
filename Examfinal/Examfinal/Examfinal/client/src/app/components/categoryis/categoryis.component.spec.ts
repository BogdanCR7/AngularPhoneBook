import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryisComponent } from './categoryis.component';

describe('CategoryisComponent', () => {
  let component: CategoryisComponent;
  let fixture: ComponentFixture<CategoryisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
