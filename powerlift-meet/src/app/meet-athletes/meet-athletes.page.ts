import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-meet-athletes',
  templateUrl: './meet-athletes.page.html',
  styleUrls: ['./meet-athletes.page.scss'],
  standalone: false
})
export class MeetAthletesPage implements OnInit {

  meet_detail_link: string = '';

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    const meetId = this.route.snapshot.paramMap.get('id');
    meetId ? this.meet_detail_link = `/tabs/meet/${meetId}` : this.meet_detail_link = '/tabs/home';
  }

}
