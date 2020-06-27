import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardiologueComponent } from './cardiologue.component';

describe('CardiologueComponent', () => {
  let component: CardiologueComponent;
  let fixture: ComponentFixture<CardiologueComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardiologueComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardiologueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
