import { Component, OnInit, ViewChild } from '@angular/core';
import { Athlete, AthleteService } from '../services/athlete.service';
import { Club, ClubService } from '../services/club.service';
import { Gender, GenderService } from '../services/gender.service';
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
  genders: Gender[] = [];
  clubs: Club[] = [];

  search: string = '';
  filter: string = 'all';

  constructor(private athleteService: AthleteService, private genderService: GenderService, private clubService: ClubService) { }

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
    this.genderService.getGenders().subscribe({
      next: (data) => this.genders = data,
      error: (err) => console.error('Error fetching genders', err)
    });
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
        (this.filter === 'men' && athlete.genderDto.name === 'Male') ||
        (this.filter === 'women' && athlete.genderDto.name === 'Female') ||
        (this.filter === 'other' && athlete.genderDto.name === 'Other');
      return matchesSearch && matchesFilter;
    });
  }

  getStatusColor(name: string) {
  }

  // Modal methods
  @ViewChild('addModal') modal!: IonModal;

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
      genderId: this.gender,
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
  }

  // View athlete details
  @ViewChild('editModal') editModal!: IonModal;

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
    this.editDateOfBirth = new Date(athlete.dateOfBirth).toISOString().split('T')[0]; 
    this.editGender = athlete.genderDto.id;
    this.editClub = athlete.clubDto.id;

    this.editModal.present();
  }

  confirmEdit() {
    //Call your update service here
    this.athleteService.updateAthlete(this.selectedAthlete.id, {
      firstName: this.editFirstName,
      lastName: this.editLastName,
      dateOfBirth: this.editDateOfBirth,
      genderId: this.editGender,
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