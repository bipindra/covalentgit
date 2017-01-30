import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { HttpInterceptorService, RESTService } from '@covalent/http';
import { MOCK_API } from '../config/api.config';

@Injectable()
export class CustomersService extends RESTService<any> {

  constructor(private _http: HttpInterceptorService) {
    super(_http, {
      baseUrl: 'http://localhost:5000',
      path: '/api/customers',
    }); 
  }

//   staticQuery(): any {
//     return this._http.get('data/items.json')
//     .map((res: Response) => {
//       return res.json();
//     }); 
//   }

//   staticGet(id: string): any {
//     return this._http.get('data/items.json')
//     .map((res: Response) => {
//       let item: any;
//       res.json().forEach((s: any) => {
//         if (s.item_id === id) {
//           item = s;
//         }
//       });
//       return item;
//     });
//   }
}
