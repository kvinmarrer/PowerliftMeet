import { Component, OnInit } from '@angular/core';
import { Athlete, AthleteService } from '../services/athlete.service';

@Component({
  selector: 'app-athletes',
  templateUrl: './athletes.page.html',
  styleUrls: ['./athletes.page.scss'],
  standalone: false
})
export class AthletesPage implements OnInit {

  athletes: Athlete[] = [];

  search: string = '';
  filter: string = 'all';

  constructor(private athleteService: AthleteService) { }

  ngOnInit() {
    this.athleteService.getAthletes().subscribe({
      next: (data) => this.athletes = data,
      error: (err) => console.error('Error fetching athletes', err)
    });
  }

  getAge(dateOfBirth: string): number {
    const birthDate = new Date(dateOfBirth);
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }

  getAgeClass(dateOfBirth: string): string {
    const age = this.getAge(dateOfBirth);

    if (age <= 18) return 'Sub-Junior';
    if (age <= 23) return 'Junior';
    if (age <= 39) return 'Open';
    return 'Master';
  }

  filterAthletes() {
  }

  getStatusColor(name: string) {
  }

}