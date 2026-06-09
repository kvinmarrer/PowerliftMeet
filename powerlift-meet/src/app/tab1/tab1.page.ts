import { Component, OnInit } from '@angular/core';
import { MeetService } from '../services/meet.service';


@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss'],
  standalone: false,
})
export class Tab1Page implements OnInit {
  meets: string[] = [];

  constructor(private meetService: MeetService) {}

  ngOnInit() {
    this.meetService.getMeets().subscribe({
      next: (data) => this.meets = data,
      error: (err) => console.error('Error fetching meets', err)
    });
  }
}