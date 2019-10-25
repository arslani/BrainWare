import { Component } from '@angular/core';
import {environment} from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public title = 'ui';

  public year = new Date().getFullYear();

 public get versionString() {
   return environment.name == 'Production' ? `V: ${environment.version}` : `V: ${environment.version} - ${environment.name}`
 }

}
