import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AngioplastieComponent } from './angioplastie.component';

describe('AngioplastieComponent', () => {
  let component: AngioplastieComponent;
  let fixture: ComponentFixture<AngioplastieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AngioplastieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AngioplastieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
