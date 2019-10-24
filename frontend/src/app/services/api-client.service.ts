import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

export interface Company {
    id: number;
    name: string;

    orders: Array<Order>;
}

export interface Order {
    id: number;
    description: string;

    companyId: number;
    company: Company;

    items: Array<OrderProduct>;
}

export interface Product {
    id: number;
    name: string;
    price: number;
}

export interface OrderProduct {
    orderId: number;
    order: Order;

    productId: number;
    product: Product;

    price: number;
    quantity: number;
}

@Injectable({ providedIn: 'root' })
export class ApiClientService {
    constructor(private httpClient: HttpClient) {
    }

    private decycle(object: any) {
        const refObjects = {};
        const loop = (obj: any) => {
            if (obj.$id)
                refObjects[obj.$id] = obj;

            for (const prop of Object.keys(obj)) {
                const p = obj[prop];
                if (!p || typeof p !== 'object')
                    continue;

                if (Array.isArray(p))
                    for (let i = 0; i < p.length; i++) {
                        const ip = p[i];
                        if (typeof ip !== 'object')
                            continue;

                        if (ip.$ref)
                            p[i] = refObjects[ip.$ref];
                        else
                            loop(ip);
                    }
                else if (p.$ref)
                    obj[prop] = refObjects[p.$ref];
                else
                    loop(p);
            }
            return obj;
        };

        loop(object);

        return object;
    }

    private getUrl(url: string, includes?: Array<string>) {
        url += '?';
        if (includes && includes.length)
            for (let i = 0; i < includes.length; i++)
                url += `&includes[${i}]=${includes[i]}`;

        return url;
    }

    private getAsync<T>(url: string): Promise<T> {
        return new Promise((resolve, reject) => {
            const headers = new HttpHeaders().set('Content-Type', 'application/json');
            this.httpClient.get<T>(environment.apiUrl + url, { headers: headers }).toPromise().then(this.decycle).then(resolve).catch(r => resolve(null));
        });
    }

    private patchAsync<T>(url: string, body: any): Promise<T> {
        return new Promise((resolve, reject) => {
            const patch = [];
            for (const p in body)
                patch.push({ op: 'replace', path: `/${p}`, value: body[p] });

            body = patch;

            const headers = new HttpHeaders().set('Content-Type', 'application/json');
            this.httpClient.patch<T>(environment.apiUrl + url, body, { headers: headers }).toPromise().then(this.decycle).then(resolve).catch(r => resolve(null));
        });
    }

    private postAsync<T>(token: string, url: string, body: any): Promise<T> {
        return new Promise((resolve, reject) => {
            const headers = new HttpHeaders().set('Content-Type', 'application/json');
            this.httpClient.post<T>(environment.apiUrl + url, body, { headers: headers }).toPromise().then(this.decycle).then(resolve).catch(r => resolve(null));
        });
    }

    private deleteAsync<T>(url: string): Promise<T> {
        return new Promise((resolve, reject) => {
            const headers = new HttpHeaders().set('Content-Type', 'application/json');
            this.httpClient.delete<T>(environment.apiUrl + url, { headers: headers }).toPromise().then(this.decycle).then(resolve).catch(r => resolve(null));
        });
    }

    public get company() {
        return {
            getOrdersAsync: (id: number, includes?: Array<string>) => this.getAsync<Array<Order>>(this.getUrl(`/Companies/${id}/Orders`, includes))
        };
    }
}

