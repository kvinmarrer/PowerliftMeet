import { Component, OnInit, ViewChild } from '@angular/core';
import { Athlete, AthleteService } from '../services/athlete.service';
import { Club, ClubService } from '../services/club.service';
import { OverlayEventDetail } from '@ionic/core/components';
import { IonModal } from '@ionic/angular';

@Component({
  selector: 'app-athletes',
  templateUrl: './athletes.page.html',
  styleUrls: ['./athletes.page.scss'],
  standalone: false,
})
export class AthletesPage implements OnInit {

  athletes: Athlete[] = [];
  filteredAthletes: Athlete[] = [];
  clubs: Club[] = [];

  search: string = '';
  filter: string = 'all';

  constructor(private athleteService: AthleteService, private clubService: ClubService) { }

  loadAthletes() {
    this.athleteService.getAthletes().subscribe({
      next: (data) => {
        this.athletes = data;
        this.filterAthletes(); 
      },
      error: (err) => console.error('Error fetching athletes', err)
    });
  }

  ngOnInit() {
    this.loadAthletes();
    this.clubService.getClubs().subscribe({
      next: (data) => this.clubs = data,
      error: (err) => console.error('Error fetching clubs', err)
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
    const searchTerm = this.search.toLowerCase();
    this.filteredAthletes = this.athletes.filter(athlete => {
      const matchesSearch = 
        athlete.firstName.toLowerCase().includes(searchTerm) || 
        athlete.lastName.toLowerCase().includes(searchTerm);
      const matchesFilter = 
        this.filter === 'all' ||
        (this.filter === 'men' && athlete.gender === 'Male') ||
        (this.filter === 'women' && athlete.gender === 'Female') ||
        (this.filter === 'other' && athlete.gender === 'Other');
      return matchesSearch && matchesFilter;
    });
  }

  getStatusColor(name: string) {
  }

  // Modal methods
  @ViewChild('addAthleteModal') modal!: IonModal;

  firstName!: string;
  lastName!: string;
  dateOfBirth!: string;
  gender!: string;
  club!: string;

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }

  confirm() {
    const athlete = {
      firstName: this.firstName,
      lastName: this.lastName,
      dateOfBirth: this.dateOfBirth,
      gender: this.gender,
      clubId: this.club,
    };
    this.modal.dismiss(athlete, 'confirm');
  }

  onWillDismiss(event: CustomEvent<OverlayEventDetail>) {
    if (event.detail.role === 'confirm') {
      const athlete = event.detail.data;
      this.athleteService.addAthlete(athlete).subscribe({
        next: () => {
          this.loadAthletes();
        },
        error: (err) => console.error('Error adding athlete', err)
      });
    }
    this.firstName = '';
    this.lastName = '';
    this.dateOfBirth = '';
    this.gender = '';
    this.club = '';
  }

  // View athlete details
  @ViewChild('editAthleteModal') editModal!: IonModal;

  selectedAthlete: any = null;

  // Edit field bindings
  editFirstName = '';
  editLastName = '';
  editDateOfBirth = '';
  editGender = '';
  editClub = '';

  openEditModal(athlete: any) {
    this.selectedAthlete = athlete;

    // Pre-populate fields
    this.editFirstName = athlete.firstName;
    this.editLastName = athlete.lastName;
    this.editDateOfBirth = athlete.dateOfBirth;
    this.editGender = athlete.gender;
    this.editClub = athlete.clubDto.id;

    this.editModal.present();
  }

  confirmEdit() {
    //Call your update service here
    this.athleteService.updateAthlete(this.selectedAthlete.id, {
      firstName: this.editFirstName,
      lastName: this.editLastName,
      dateOfBirth: this.editDateOfBirth,
      gender: this.editGender,
      clubId: this.editClub,
    }).subscribe(() => {
      this.editModal.dismiss();
      this.loadAthletes();
    });
  }

  onEditDismiss(event: any) {
    this.selectedAthlete = null;
  }

  // Delete athlete
  deleteAthlete(athleteId: string) {
    this.athleteService.deleteAthlete(athleteId).subscribe({
      next: () => {
        this.loadAthletes();
      },
      error: (err) => console.error('Error deleting athlete', err)
    });
  }
  
}