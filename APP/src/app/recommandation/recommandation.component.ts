import { Component, OnInit } from '@angular/core';
import { ServiceDetail, ServiceRecom } from '../Model/Service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-recommandation',
  templateUrl: './recommandation.component.html',
  styleUrls: ['./recommandation.component.css']
})
export class RecommandationComponent implements OnInit {

  Services!: ServiceRecom[];
  Service!: ServiceDetail;
  public RecommForm !: FormGroup;
  
  constructor(private http: HttpClient, private formBuilder : FormBuilder) { }

  ngOnInit(): void {
    this.RecommForm = this.formBuilder.group({
      categorieId : 1,
      serviceId : 4,
      Avis: [''],
      Commentaire: [''],
    })
    this.getServiceRecom()
    .subscribe( data => {
      this.Services = data;
      console.log(this.Services[0].Commentaire,"data")
      console.log("check",this.Services[0].Avis == 2)
    });
    this.getService()
    .subscribe( data => {
      this.Service = data;
    });
  }
  getServiceRecom() {
    return this.http.get<ServiceRecom[]>("https://localhost:44366/ServiceRecom/1");
  }
  getService() {
    return this.http.get<ServiceDetail>("https://localhost:44366/Service/1");
  }
  rangeA(k : number) {

    var a = []

    for (let i = 0; i < k; i++) {

      a.push(i)

    }

    return a ;

  }
  PostRecom(){
    this.http.post<any>("https://localhost:44366/Recommandation", this.RecommForm.value)
    
  }
}
