import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Symbiote {
  id: string;
  name: string;
  isComplete: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public symbiotes: Symbiote[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.http.get<Symbiote[]>('/api/Todo/all').subscribe(
      (result) => {
        this.symbiotes = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'symbiote.client';
}
