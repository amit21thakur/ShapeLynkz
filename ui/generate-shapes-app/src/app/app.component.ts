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

  DecodeQuery(){

      this._shapeService.decode(this.queryText).subscribe(
        (response) => {
          console.log(response);
          this.result = response;
          console.log(this.result);
      },
        (err) => {
          console.log(err)
          },

      );
  }


}
