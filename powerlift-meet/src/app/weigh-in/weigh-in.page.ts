import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-weigh-in',
  templateUrl: './weigh-in.page.html',
  styleUrls: ['./weigh-in.page.scss'],
  standalone: false
})
export class WeighInPage implements OnInit {

  meet_detail_link: string = '/tabs/home';
  meet_id: string = '';

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')!;
    this.meet_id = id;
    this.meet_detail_link = `/tabs/meet-detail/${id}`;
  }

}
