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
  hasError = false;

  DecodeQuery()
  {
    this._shapeService.decode(this.queryText).subscribe(
        (response) => {
          console.log(response);
          this.setData(response);
      },
        (err) => {
          console.log(err);
          this.hasError = true;
          },

      );
  }

  polygonPoints = "";
  isoscelesTrianglePoints = "";
  scaleneTrianglePoints = "";
  parallelogramPoints = "";

  isRegularPolygon = false;
  polygonHeight = 0;
  polygonWidth = 0;

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
        var angle = 0;

        this.polygonHeight = response.sideLength * 2.5;
        this.polygonWidth = response.sideLength * 2.5;
        switch(response.name)
        {
          case "equilateral_triangle":
          sides = 3;
          angle=60;
          break;
          case "square":
          sides = 4;
          break;
          case "pentagon":
          sides = 5;
          angle = 36;
          break;
          case "hexagon":
          sides = 6;
          break;
          case "heptagon":
          sides = 7;
          angle=25.7145;
          break;
          case "octagon":
          sides = 8;
          break;
        }
        var vertices = polygon.coordinates(sides, response.sideLength, angle);
        var i;
        this.polygonPoints="";
        for (i = 0; i < vertices.length; i++) 
        { 
          this.polygonPoints += vertices[i].x + "," + vertices[i].y + "  ";
        }
      }
      if(response.name === "isosceles_triangle")
      {
        this.polygonPoints = "0,"+response.height +"  "+ response.width+","+response.height + "  " + response.width/2 + ",0";
        this.polygonHeight = response.height + 5;
        this.polygonWidth = response.width + 5;
      }
      if(response.name === "scalene_triangle")
      {
        //TODO : check for invalid triangle request - which are not possible
        var x = Math.sqrt((response.sideLength * response.sideLength) - (response.height * response.height));
        this.polygonPoints = "0," + response.height + "  " + response.width + "," + response.height + "  " + x + ",0";
        this.polygonHeight = response.height + 5;
        this.polygonWidth = Math.max(response.width, x) +5;
      }
      if(response.name === "parallelogram")
      {
        var x = Math.sqrt((response.sideLength * response.sideLength) - (response.height * response.height));
        this.polygonPoints = "0," + response.height + "  " + response.width + "," + response.height + "  " + (x+response.width) +",0  " + x + ",0";
        this.polygonHeight = response.height + 5;
        this.polygonWidth = response.width + x +5;
      }
   }

}
