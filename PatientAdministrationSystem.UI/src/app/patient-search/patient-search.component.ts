import { Component } from '@angular/core';
import { PatientSearchService } from '../patient-search.service';

@Component({
  selector: 'app-patient-search',
  templateUrl: './patient-search.component.html',
  styleUrls: ['./patient-search.component.css']
})
export class PatientSearchComponent {
  query: string = '';
  patients: any[] = [];
  error: string | null = null;
  noResults: boolean = false;

  constructor(private patientSearchService: PatientSearchService) { }

  searchPatients(): void {
    if (this.query.length === 0 || this.query.length > 100) {
      this.error = 'Search query cannot be null or empty.Please serach with valid patient details..!';
      return;
    }

    this.patientSearchService.searchPatients(this.query).subscribe({
      next: (data) => {
        this.patients = data;
        this.noResults = this.patients.length === 0;
        this.error = null;
      },
      error: (err) => {
        this.error = 'Error fetching patient data.';
        this.noResults = false;
        console.error(err);
      }
    });
  }
}