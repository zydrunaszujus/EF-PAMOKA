import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  constructor(private apiService:ApiService) { }//metodas kreipsis i api servisa

automobiliai:any[]=[]//automobiliu spausdinimui

  ngOnInit(): void {//marke ir modelis is mazuju,tam kad,jei padirbus tokena,leidzia prieiti prie main puslapio, bet rodys tik siutos duomenis kurie bus mazosiomis raidemis, nes main.html irasyta isvestis i ekrana is frontend.
    let test={Id:"0",marke:"Jus neprisijunges",modelis:"Prisijungtite",SavininkoId:"0"}//surasoma, kad yra API automobiliai klaseje,kaip pavyzdi
  this.automobiliai.push(test)//bus uzpildytas automobilis
  this.automobiliai.push(test)
  this.automobiliai.push(test)
  this.gautiAutomobilius()
 
}
atsijungti(){
this.apiService.atsijungti();//aprasytas bus api.service.ts
}

async gautiAutomobilius(){
  let atsakymasIsServerio=await fetch("https://localhost:44325/automobiliai",{
      headers : {
        'Content-type': 'application/json',//istraukta is ineterneto
        'Authorization': `Bearer ${this.apiService.token}`,
    }
  })
console.log(atsakymasIsServerio);
let gautiAutomobiliai=await atsakymasIsServerio.json();
console.log(gautiAutomobiliai)
if (atsakymasIsServerio.status == 401) {
  this.automobiliai=[]
}
if (gautiAutomobiliai != null && atsakymasIsServerio.status == 200){
this.automobiliai=gautiAutomobiliai
}

}

}
