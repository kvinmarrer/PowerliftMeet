import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IonModal } from '@ionic/angular';
import { OverlayEventDetail } from '@ionic/core/components';
import { MeetAthlete, MeetAthleteService } from '../services/meetathlete.service';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { Flight, FlightService } from '../services/flight.service';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.page.html',
  styleUrls: ['./flight.page.scss'],
  standalone: false
})
export class FlightPage implements OnInit {

  flights: Flight[] = [];
  unassignedAthletes: MeetAthlete[] = [];
  selectedAthletes: MeetAthlete[] = [];
  meet_detail_link: string = '';
  meetId: string = '';

  searchTerm: string = '';

  constructor(private route: ActivatedRoute, private meetAthleteService: MeetAthleteService, private flightService: FlightService) { }

  loadData() {
    this.loadMeetAthletes();
    this.loadFlights();
  }

  ngOnInit() {
    this.meetId = this.route.snapshot.paramMap.get('meetId') || '';
    this.meet_detail_link = `tabs/meet/${this.meetId}`;

    this.loadData();
  }

  @ViewChild('addFlightModal') addFlightModal!: IonModal;

  label: string = '';
  labelOptions = [
    { value: 'A', label: 'A' },
    { value: 'B', label: 'B' },
    { value: 'C', label: 'C' },
    { value: 'D', label: 'D' },
    { value: 'E', label: 'E' },
    { value: 'F', label: 'F' },
    { value: 'G', label: 'G' },
    { value: 'H', label: 'H' },
    { value: 'I', label: 'I' },
    { value: 'J', label: 'J' },
    { value: 'K', label: 'K' },
  ];

  loadMeetAthletes() {
    this.meetAthleteService.getMeetAthletesByMeetId(this.meetId).subscribe(ma => {
      // Filter out athletes that are already assigned to a flight
      this.unassignedAthletes = ma.filter(a => !this.flights.some(f => f.meetAthletes.some(fa => fa.id === a.id)));
      this.selectedAthletes = [];
    });
  }

  loadFlights() {
    this.flightService.getFlightsByMeetId(this.meetId).subscribe(flights => {
      this.flights = flights;
      // after loading flights, reload unassigned athletes to ensure they are up-to-date
      this.loadMeetAthletes();
    });
  }

  onSearchInput() {
  }

  drop(event: CdkDragDrop<MeetAthlete[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    }
  }

  confirm() {
    const newFlight = {
      meetId: this.meetId,
      label: this.label,
      meetAthleteIds: this.selectedAthletes.map(a => a.id)
    };
    this.addFlightModal.dismiss(newFlight, 'confirm');
  }

  cancel() {
    this.addFlightModal.dismiss(null, 'cancel');
  }

  onWillDismiss(event: CustomEvent<OverlayEventDetail<any>>) {
    if (event.detail.role === 'confirm') {
        const flight = event.detail.data;
        this.flightService.addFlightToMeet(this.meetId, flight).subscribe({
          next: () => {
            this.loadData();
          },
          error: (err) => console.error('Error adding flight', err)
        });
      }
  }

  deleteFlight(flightId: string) {
    this.flightService.deleteFlight(flightId).subscribe({
      next: () => {
        this.loadData();
      },
      error: (err) => console.error('Error deleting flight', err)
    });
  }

}
