import { Component } from '@angular/core';

@Component({
  selector: 'app-description',
  templateUrl: './description.component.html',
  styleUrls: ['./description.component.css']
})
export class DescriptionComponent {
  description: string = "This is a URL Shortener algorithm that takes a long URL and creates a shorter, unique URL.";
  isAdmin: boolean = false; 

  updateDescription() {
    if (this.isAdmin) {
      console.log('Updated description:', this.description);
    }
  }
}
