import { Component, OnInit } from '@angular/core';
import { Customer} from './customer';
import { CustomersService } from '../../services/';
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss'],
  viewProviders : [CustomersService]
})
export class CustomersComponent implements OnInit {

  public customers:Array<Customer>=[];
  public columns:any=[
    {name:"id",numeric:true,label:"Id"},
    {name:"companyName",numeric:true,label:"Company Name"},
    {name:"contactName",label:"Contact Name"}
  ];
  constructor(public _ordersServices:CustomersService) { }

  ngOnInit() {
    let query = this._ordersServices.query({pageSize:20,pageNumber:1});
    query.subscribe(e=>{
      this.customers = e;
    });
  }

}
