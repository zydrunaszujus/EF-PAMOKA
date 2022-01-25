import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(private apiService:ApiService) { }//metodas kreipsis i api servisa

  ngOnInit(): void {
  }
atsijungti(){
this.apiService.atsijungti();//aprasytas bus api.service.ts
}

}
