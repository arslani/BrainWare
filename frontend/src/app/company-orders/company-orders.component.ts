import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiClientService, Order } from '../services/api-client.service';

@Component({
  selector: 'app-company-orders',
  templateUrl: './company-orders.component.html',
  styleUrls: ['./company-orders.component.scss']
})
export class CompanyOrdersComponent implements OnInit {

  private companyId: number;

  public orders:Array<any> = [];

  public constructor(private route: ActivatedRoute, private apiClient: ApiClientService) {
    this.companyId = parseInt(this.route.snapshot.paramMap.get('id') || '1');
  }

  public async ngOnInit() {
     const response = await this.apiClient.company.getOrdersAsync(this.companyId, ["Items.Product"]);
     for(let order of response){
        let price = 0;
        for(let item of order.items)
          price += item.price * item.quantity;
        
          (<any>order).price = price;
     }

     this.orders = response;
  }

}
