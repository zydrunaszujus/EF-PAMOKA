import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private router:Router) { }//kad naviguotu i kita puslapi

  token = ''

  async prisijungti(data: any) {
    data.Id=0
    data.Pastas=""//neskaitom is API siu reiksmiu

    let atsakymasIsServerio = await fetch('https://localhost:44325/login', {
      method: 'POST',
      headers: {
        'Accept': 'application/json, text/plain, */*',
        'Content-Type': 'application/json'
      },

      body: JSON.stringify(data)
    })
    
    let tokenas = await atsakymasIsServerio?.json()
    
    if(atsakymasIsServerio.status==401){
      alert("Netinkamas slaptazodis")
    }

    if (tokenas != null&&atsakymasIsServerio.status==200) {
      console.log(tokenas)//jei gaUname tokena,tuomet naviguoja i main
      this.router.navigate(['main'])
    }
  }

}
