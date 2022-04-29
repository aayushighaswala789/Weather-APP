import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { map, delay } from 'rxjs/operators';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { getWeatherForCityModel } from '../models/Location';
import { getWeeklyWeatherForCityModel } from '../models/WeeklyWeather';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})

export class WeatherService {
  constructor(
    private http: HttpClient,
    private snackBar: MatSnackBar) { }


  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  getWeatherForCity(city: string): Observable<getWeatherForCityModel[]> {
    return this.http.get<getWeatherForCityModel[]>(`${environment.baseURL}Location/${city}`).pipe(
      tap((res: getWeatherForCityModel[]) => {
        if (res.length === 0) {
          // Manage No Data response
          this.snackBar.open('No city found.', 'Dismiss', {
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
        }
      }),
    )
  }

  getWeeklyWeatherForCity(key: number): Observable<getWeeklyWeatherForCityModel[]> {
    return this.http.get<getWeeklyWeatherForCityModel[]>(`${environment.baseURL}WeatherForecast/${key}`)
  }

}
