import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/catch';

@Injectable()
export class ShapeService{
    constructor(private http: HttpClient)    { }

    baseUri:string = "http://localhost:20298/api/shape";
    
    decode(query:string){
        var url = url + "?query=" + query;
        return this.http.get(url);
    }

}