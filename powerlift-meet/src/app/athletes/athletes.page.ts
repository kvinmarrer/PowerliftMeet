import { Component, OnInit, ViewChild } from '@angular/core';
import { Athlete, AthleteService } from '../services/athlete.service';
import { Federation, FederationService } from '../services/federation.service';
import { WeightClass, WeightClassService } from '../services/weightclass.service';
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
  weightClasses: WeightClass[] = [];
  federations: Federation[] = [];

  search: string = '';
  filter: string = 'all';

  constructor(private athleteService: AthleteService, private weightClassService: WeightClassService, private federationService: FederationService) { }

  loadAthletes() {
    this.athleteService.getAthletes().subscribe({
      next: (data) => this.athletes = data,
      error: (err) => console.error('Error fetching athletes', err)
    });
  }

  ngOnInit() {
    this.loadAthletes();
    this.weightClassService.getWeightClasses().subscribe({
      next: (data) => this.weightClasses = data,
      error: (err) => console.error('Error fetching weight classes', err)
    });
    this.federationService.getFederations().subscribe({
      next: (data) => this.federations = data,
      error: (err) => console.error('Error fetching federations', err)
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

  // Modal methods
  @ViewChild('addModal') modal!: IonModal;

  firstName!: string;
  lastName!: string;
  dateOfBirth!: string;
  weightClass!: string;
  federation!: string;
  selectedGender!: string;

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }

  confirm() {
    const athlete = {
      firstName: this.firstName,
      lastName: this.lastName,
      dateOfBirth: this.dateOfBirth,
      weightClassId: this.weightClass,
      federationId: this.federation,
      gender: this.selectedGender
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
  editWeightClass = '';
  editFederation = '';
  editGender = '';

  openEditModal(athlete: any) {
    this.selectedAthlete = athlete;

    // Pre-populate fields
    this.editFirstName = athlete.firstName;
    this.editLastName = athlete.lastName;
    this.editDateOfBirth = new Date(athlete.dateOfBirth).toISOString().split('T')[0]; 
    this.editWeightClass = athlete.weightClassDto.id;
    this.editFederation = athlete.federationDto.id;
    this.editGender = athlete.gender;

    this.editModal.present();
  }

  confirmEdit() {
    //Call your update service here
    this.athleteService.updateAthlete(this.selectedAthlete.id, {
      firstName: this.editFirstName,
      lastName: this.editLastName,
      dateOfBirth: this.editDateOfBirth,
      weightClassId: this.editWeightClass,
      federationId: this.editFederation,
      gender: this.editGender,
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