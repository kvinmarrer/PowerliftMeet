import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MeetDetailPage } from './meet-detail.page';

describe('MeetDetailPage', () => {
  let component: MeetDetailPage;
  let fixture: ComponentFixture<MeetDetailPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(MeetDetailPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
