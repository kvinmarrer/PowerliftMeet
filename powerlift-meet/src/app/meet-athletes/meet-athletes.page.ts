import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IonModal } from '@ionic/angular';
import { OverlayEventDetail } from '@ionic/core/components';
import { MeetAthlete, MeetAthleteService } from '../services/meetathlete.service';
import { Athlete, AthleteService } from '../services/athlete.service';
import { WeightClass, WeightClassService } from '../services/weightclass.service';


@Component({
  selector: 'app-meet-athletes',
  templateUrl: './meet-athletes.page.html',
  styleUrls: ['./meet-athletes.page.scss'],
  standalone: false
})
export class MeetAthletesPage implements OnInit {

  meetAthletes: MeetAthlete[] = [];
  filteredMeetAthletes: MeetAthlete[] = [];
  allAthletes: Athlete[] = [];
  meet_detail_link: string = '';
  meetId: string = '';
  searchTerm: string = '';

  constructor(private route: ActivatedRoute, private meetAthleteService: MeetAthleteService, private athleteService: AthleteService, private weightClassService: WeightClassService) { }

  loadMeetAthletes() {
    if (this.meetId) {
      this.meetAthleteService.getMeetAthletesByMeetId(this.meetId).subscribe({
        next: (data) => {
          this.meetAthletes = data;
          this.onSearchInput();
        },
        error: (err) => console.error('Error fetching meet athletes', err)
      });
    }
  }

  ngOnInit() {
    this.meetId = this.route.snapshot.paramMap.get('meetId') || '';
    this.meet_detail_link = this.meetId ? `/tabs/meet/${this.meetId}` : '/tabs/home';

    this.loadMeetAthletes();

    this.athleteService.getAthletes().subscribe({
      next: (data) => {
        this.allAthletes = data;
      },
      error: (err) => console.error('Error fetching all athletes', err)
    });
  }

  get availableAthletes(): Athlete[] {
    const meetAthleteIds = new Set(this.meetAthletes.map(ma => ma.athleteId));
    return this.allAthletes.filter(athlete => !meetAthleteIds.has(athlete.id));
  }

  onSearchInput() {
    const searchTerm = this.searchTerm.toLowerCase();
    this.filteredMeetAthletes = this.meetAthletes.filter(ma => {
      const fullName = `${ma.athleteDto.firstName} ${ma.athleteDto.lastName}`.toLowerCase();
      return fullName.includes(searchTerm) || ma.athleteDto.clubDto.name.toLowerCase().includes(searchTerm);
    });
  }

  @ViewChild('addMeetAthleteModal') addMeetAthleteModal!: IonModal;

  athletes: Athlete[] = [];
  filteredWeightClasses: WeightClass[] = [];
  selectedAthleteId: string = '';
  selectedWeightClassId: string = '';

  onAthleteSelected() {
    this.weightClassService.getWeightClassesByAthleteGender(this.selectedAthleteId).subscribe({
      next: (data) => {
        this.filteredWeightClasses = data;
      },
      error: (err) => console.error('Error fetching weight classes for selected athlete', err)
    });
  }

  cancel() {
      this.addMeetAthleteModal.dismiss(null, 'cancel');
    }
  
    confirm() {
      const newMeetAthlete = {
        athleteId: this.selectedAthleteId,
        weightClassId: this.selectedWeightClassId
      };
      this.addMeetAthleteModal.dismiss(newMeetAthlete, 'confirm');
    }

    onWillDismiss(event: CustomEvent<OverlayEventDetail>) {
      if (event.detail.role === 'confirm') {
        const meetAthlete = event.detail.data;
        this.meetAthleteService.addMeetAthleteToMeet(this.meetId, meetAthlete).subscribe({
          next: () => {
            this.loadMeetAthletes();
          },
          error: (err) => console.error('Error adding meet athlete', err)
        });
      }
    }

    @ViewChild('editMeetAthleteModal') editMeetAthleteModal!: IonModal;
    selectedMeetAthlete: any | null = null;
    editedWeightClass: WeightClass = {} as WeightClass;

    openEditMeetAthleteModal(meetAthlete: any) {
      this.selectedMeetAthlete = meetAthlete;
      this.selectedWeightClassId = meetAthlete.weightClassId;
      this.selectedAthleteId = meetAthlete.athleteId;
      this.onAthleteSelected();
      this.editMeetAthleteModal.present();
    }

    cancelEdit() {
      this.editMeetAthleteModal.dismiss(null, 'cancel');
    }

    confirmEdit() {
      this.meetAthleteService.editMeetAthlete(this.selectedMeetAthlete.id, { weightClassId: this.selectedWeightClassId }).subscribe({
        next: () => {
          this.loadMeetAthletes();
        },
        error: (err) => console.error('Error editing meet athlete', err)
      });

      this.editMeetAthleteModal.dismiss(null, 'confirm');
    }

    onEditWillDismiss(event: CustomEvent<OverlayEventDetail>) {
      this.selectedMeetAthlete = null;
    }

    deleteMeetAthlete(meetAthleteId: string) {
      this.meetAthleteService.deleteMeetAthlete(meetAthleteId).subscribe({
        next: () => { 
          this.loadMeetAthletes();
        },
        error: (err) => console.error('Error deleting meet athlete', err)
      });
    }

    getAgeClass(dateOfBirth: string): string {
      const birthYear = new Date(dateOfBirth).getFullYear();
      const currentYear = new Date().getFullYear();
      const age = currentYear - birthYear;

      if (age < 18) {
        return 'Junior';
      } else if (age >= 18 && age < 40) {
        return 'Open';
      } 

      return 'Master';
    }
  
}
