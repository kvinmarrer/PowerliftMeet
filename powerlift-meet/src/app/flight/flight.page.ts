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
      meetAthleteIdWithLots: this.selectedAthletes.map((a, index) => ({
        id: a.id,
        lot: index + 1, 
      }))
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

  @ViewChild('editFlightModal') editFlightModal!: IonModal;
  flightToEdit: Flight | null = null;
  editFlightLabel: string = '';
  editFlightNumber: number = 0;
  dragAndDropAthletes: MeetAthlete[] = [];

  openEditFlightModal(flight: Flight) {
    this.flightToEdit = { ...flight, meetAthletes: [...flight.meetAthletes] };
    this.editFlightLabel = flight.label;
    this.editFlightNumber = flight.flightNumber;

    this.selectedAthletes = [...flight.meetAthletes].sort((a, b) => {
      const lotA = a.lot || 0;
      const lotB = b.lot || 0;
      return lotA - lotB;
    });

    const otherFlightAthleteIds = this.flights
      .filter(f => f.id !== flight.id)
      .reduce((acc, f) => acc.concat(f.meetAthletes.map(a => a.id)), [] as string[]);

    this.meetAthleteService.getMeetAthletesByMeetId(this.meetId).subscribe(ma => {
      this.unassignedAthletes = ma.filter(a => !otherFlightAthleteIds.includes(a.id) 
        && !flight.meetAthletes.some(fa => fa.id === a.id));
      this.editFlightModal.present();
    });
}

  confirmEdit() {
    if (this.flightToEdit) {
      const request = {
        label: this.editFlightLabel,
        flightNumber: this.editFlightNumber,
        meetAthleteIdWithLots: this.selectedAthletes.map((a, index) => ({
          id: a.id,
          lot: index + 1
        }))
      };
      this.flightService.editFlight(this.flightToEdit.id, request).subscribe({
        next: () => {
          this.loadData();
          this.editFlightModal.dismiss();
        },
        error: (err) => console.error('Error updating flight', err)
      });
    }
  }

  onEditDismiss(event: CustomEvent<OverlayEventDetail<any>>) {
    this.flightToEdit = null;
    this.selectedAthletes = [];  
    this.loadMeetAthletes();     
  }

}
