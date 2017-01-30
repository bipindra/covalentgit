import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../../services/';
import {Order} from './order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
  viewProviders : [OrdersService]
})
export class OrdersComponent implements OnInit {
  public orders:Array<Order>=[];
  public columns:any=[
    {name:"id",numeric:true,label:"Id"},
    {name:"freight",numeric:true,label:"Amount"},
    {name:"shipName",label:"Ship Name"}
  ];
  constructor(public _ordersServices:OrdersService) { }

  ngOnInit() {
    let query = this._ordersServices.query({pageSize:20,pageNumber:1});
    query.subscribe(e=>{
      this.orders = e;
    });
  }

}


