import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoronarographieComponent } from './coronarographie.component';

describe('CoronarographieComponent', () => {
  let component: CoronarographieComponent;
  let fixture: ComponentFixture<CoronarographieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoronarographieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoronarographieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
