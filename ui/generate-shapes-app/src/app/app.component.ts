import { Component } from '@angular/core';
import { NgModel } from '@angular/forms';

import {ShapeService} from './shape.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[ShapeService]
})
export class AppComponent {
  title = 'generate-shapes-app';

  private _shapeService: ShapeService;

  constructor(private shapeService: ShapeService)
  {
    this._shapeService = shapeService;
  }

  result = null;
  queryText:string;

  DecodeQuery()
  {
    this._shapeService.decode(this.queryText).subscribe(
        (response) => {
          console.log(response);
          this.setData(response);
      },
        (err) => {
          console.log(err)
          },

      );
  }

  polygonPoints:string;
  
   setData(response)
   {
     this.result = response;

     if( response.name == "equilateral_triangle" || 
          response.name == "square" || 
          response.name == "pentagon" || 
          response.name == "hexagon" || 
          response.name == "heptagon" || 
          response.name == "octagon" )
          {
            var polygon = require("polygon-generator");
            var sides = 5;
            var vertices = polygon.coordinates(sides, response.side_length, 0);
            console.log(vertices);
            //polygonPoints
          }
   }

}
