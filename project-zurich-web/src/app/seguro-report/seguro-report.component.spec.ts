import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeguroReportComponent } from './seguro-report.component';

describe('SeguroReportComponent', () => {
  let component: SeguroReportComponent;
  let fixture: ComponentFixture<SeguroReportComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeguroReportComponent]
    });
    fixture = TestBed.createComponent(SeguroReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
