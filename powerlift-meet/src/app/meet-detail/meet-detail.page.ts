import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Meet, MeetService } from '../services/meet.service';

@Component({
  selector: 'app-meet-detail',
  templateUrl: './meet-detail.page.html',
  styleUrls: ['./meet-detail.page.scss'],
  standalone: false
})
export class MeetDetailPage implements OnInit {
  meet?: any;
  athleteCount = 0;
  flightCount = 0;

  get canStart(): boolean {
    return this.athleteCount > 0;
  }

  constructor(
    private route: ActivatedRoute,
    private meetService: MeetService
  ) {}

  ngOnInit() {
  }

  ionViewWillEnter() {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.meetService.getMeetById(id).subscribe(meet => {
      this.meet = meet;
      this.athleteCount = meet.meetAthletes?.length ?? 0;
      this.flightCount = meet.flights?.length ?? 0;
    });
  }

  startMeet() {

  }
}
