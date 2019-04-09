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

  polygonPoints = "";
  isoscelesTrianglePoints = "";
  scaleneTrianglePoints = "";
  parallelogramPoints = "";

  isRegularPolygon = false;

   setData(response)
   {
     this.result = response;

     this.isRegularPolygon =
      response.name == "equilateral_triangle" || 
      response.name == "square" || 
      response.name == "pentagon" || 
      response.name == "hexagon" || 
      response.name == "heptagon" || 
      response.name == "octagon";
      if(this.isRegularPolygon)    
      {
        var polygon = require("polygon-generator");
        var sides = 0;
        switch(response.name)
        {
          case "equilateral_triangle":
          sides = 3;
          break;
          case "square":
          sides = 4;
          break;
          case "pentagon":
          sides = 5;
          break;
          case "hexagon":
          sides = 6;
          break;
          case "heptagon":
          sides = 7;
          break;
          case "octagon":
          sides = 8;
          break;
        }
        var vertices = polygon.coordinates(sides, response.side_length, 0);
        var i;
        for (i = 0; i < vertices.length; i++) 
        { 
          this.polygonPoints += vertices[i].x + "," + vertices[i].y + "  ";
        }
      }
      if(response.name === "isosceles_triangle")
      {

      }
      if(response.name === "scalene_triangle")
      {

      }
      if(response.name === "parallelogram")
      {

      }
   }

}
