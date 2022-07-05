// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { HttpHeaders } from "@angular/common/http";

 
const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': 'http://localhost:4200',
    'Access-Control-Allow-Methods': 'POST, GET, PUT, OPTIONS, DELETE',
    'Access-Control-Allow-Headers': 'x-requested-with, content-type',
  })
}

export const environment = {
  production: false,
  API_URL: 'https://localhost:44344/api/',
  httpOptions: httpOptions
};
