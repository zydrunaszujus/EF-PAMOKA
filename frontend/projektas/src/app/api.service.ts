import { Injectable } from '@angular/core';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
//pridetas AUthGuerd apsauga       ,private auth:AuthGuard rasomas,kai viska iena is auth.guard
  constructor(private router:Router) { //kad naviguotu i kita puslapi
 let browserToken=localStorage.getItem('token');//localStorage yra puslapio(brauzerio) atmintis,bandom pasiimti tokena
 if(browserToken!=null){//jei yra tokenas tuomet token tampa brauserToken
this.loggedIn=true;//leidziam prisijungti,jei turim tokena teisinga
  this.token=browserToken;//isirso i brauzer tokena
 }
  }
  loggedIn=false;  //prisijungimas false,kad nepasiekti main lapo
  token = ''

atsijungti(){//pries loggedIn prirasom ath,jei eitu loggedIn eitu is auth.gurard
  this.loggedIn=false;  //paspaudus atsijungti is main puslapio,loggedIn padarom false,reiskiasi prisijungimas false

  localStorage.removeItem('token'); //isims tokena

  this.router.navigate(["login"]);//kad paspaudus mygtuka,nuvestu i login lapa
}

  async prisijungti(data: any) {
    data.Id=0
    data.Pastas=""//nes neskaitom is API siu reiksmiu,sukuriam tuscia vieta,kad nemestu klaidu

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
      console.log(tokenas) //jei gaUname tokena,tuomet naviguoja i main
      this.loggedIn=true; //jei atsisutas is auth.quard true
     
      this.token=tokenas;//prisiskiriam tokena token
      localStorage.setItem('token',this.token);//issaugom tokena
      
      this.router.navigate(['main']);
    }
  }



async registruotis(data: any) {
  data.Id=0
 

  let atsakymasIsServerio = await fetch('https://localhost:44325/register', {
    method: 'POST',
    headers: {
      'Accept': 'application/json, text/plain, */*',
      'Content-Type': 'application/json'
    },

    body: JSON.stringify(data)
  })
  
  let tokenas = await atsakymasIsServerio?.json()
  
  if(atsakymasIsServerio.status==401){
    alert("Toks vartotojas jau egzistuoja")
  }

  if (tokenas != null&&atsakymasIsServerio.status==200) {
    console.log(tokenas)//jei gaUname tokena,tuomet naviguoja i main
    this.loggedIn=true;

    this.token=tokenas;//prisiskiriam tokena token
      localStorage.setItem('token',this.token)//issaugom tokena


    this.router.navigate(['main'])
  }
}
}
