import { Component, OnInit } from '@angular/core';
import { MeetService } from '../services/meet.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
  standalone: false
})
export class HomePage implements OnInit {

  meets: string[] = [];

  constructor(private meetService: MeetService) {}

  ngOnInit() {
    this.meetService.getMeets().subscribe({
      next: (data) => this.meets = data,
      error: (err) => console.error('Error fetching meets', err)
    });
  }

}
