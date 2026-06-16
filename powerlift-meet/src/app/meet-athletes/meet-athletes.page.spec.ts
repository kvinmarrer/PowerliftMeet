import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MeetAthletesPage } from './meet-athletes.page';

describe('MeetAthletesPage', () => {
  let component: MeetAthletesPage;
  let fixture: ComponentFixture<MeetAthletesPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(MeetAthletesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
