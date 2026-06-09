import { Component, OnInit } from '@angular/core';
import { AthleteService } from '../services/athlete.service';

@Component({
  selector: 'app-athletes',
  templateUrl: './athletes.page.html',
  styleUrls: ['./athletes.page.scss'],
  standalone: false
})
export class AthletesPage implements OnInit {

  athletes: string[] = [];

  constructor(private athleteService: AthleteService) { }

  ngOnInit() {
    this.athleteService.getAthletes().subscribe({
      next: (data) => this.athletes = data,
      error: (err) => console.error('Error fetching athletes', err)
    });
  }

}