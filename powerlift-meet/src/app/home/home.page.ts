import { Component, OnInit } from '@angular/core';
import { MeetService } from '../services/meet.service';
import { IonModal } from '@ionic/angular';
import { ViewChild } from '@angular/core';
import { OverlayEventDetail } from '@ionic/core/components';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
  standalone: false
})
export class HomePage implements OnInit {

  meets: any[] = [];

  constructor(private meetService: MeetService) {}

  
  loadMeets() {
    this.meetService.getMeets().subscribe({
      next: (data) => this.meets = data,
      error: (err) => console.error('Error fetching meets', err)
    });
  }

  ngOnInit() {
    this.loadMeets();
  }

  // Add method
  @ViewChild('addMeetModal') modal!: IonModal;

  name!: string;
  date!: string;
  location!: string;
  description!: string;

  cancel() {
    this.modal.dismiss(null, 'cancel');
  }

  confirm() {
    const meet = {
      name: this.name,
      date: this.date,
      location: this.location,
      description: this.description
    };
    this.modal.dismiss(meet, 'confirm');
  }

  onWillDismiss(event: CustomEvent<OverlayEventDetail>) {
    if (event.detail.role === 'confirm') {
      const meet = event.detail.data;
      this.meetService.addMeet(meet).subscribe({
        next: () => {
          this.loadMeets();
        },
        error: (err) => console.error('Error adding meet', err)
      });
    }
  }

  // Edit method
  @ViewChild('editMeetModal') editModal!: IonModal;
  selectedMeet: any = null;

  editName!: string;
  editDate!: string;
  editLocation!: string;
  editDescription!: string;

  editMeet(meet: any) {
    this.selectedMeet = meet;

    this.editName = meet.name;
    this.editDate = meet.date;
    this.editLocation = meet.location;
    this.editDescription = meet.description;
    this.editModal.present();
  }

  confirmEdit() {
   this.meetService.editMeet(this.selectedMeet.id, {
    name: this.editName, 
    date: this.editDate, 
    location: this.editLocation, 
    description: this.editDescription
  }).subscribe({
      next: () => {
        this.editModal.dismiss();
        this.loadMeets();
      }
    });
  }

  cancelEdit() {
    this.editModal.dismiss(null, 'cancel');
  }

  deleteMeet(meetId: string) {
    this.meetService.deleteMeet(meetId).subscribe({
      next: () => {
        this.loadMeets();
      },
      error: (err) => console.error('Error deleting meet', err)
    });
  }
}
