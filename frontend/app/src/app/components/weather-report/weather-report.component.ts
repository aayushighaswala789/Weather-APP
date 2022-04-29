import { ChangeDetectorRef, Component, DoCheck, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { cloneDeep } from 'lodash';
import * as moment from 'moment';
import { Observable, Subscription, debounceTime, distinctUntilChanged } from 'rxjs';
import { map, filter, concatMap, tap } from 'rxjs/operators';

import { getWeatherForCityModel } from 'src/app/models/Location';
import { getWeeklyWeatherForCityModel } from 'src/app/models/WeeklyWeather';
import { WeatherService } from 'src/app/services/weather.service';
@Component({
  selector: 'app-weather-report',
  templateUrl: './weather-report.component.html',
  styleUrls: ['./weather-report.component.scss'],

})
export class WeatherReportComponent implements OnInit, OnDestroy {

  subcription: Subscription;
  cityCTRL: FormControl = new FormControl()
  allCities: getWeatherForCityModel[] = []
  weeklyWeather: getWeeklyWeatherForCityModel[] = []
  weeklyWeatherData: any[] = []
  selectedWeather: any
  dayNight!: string
  today = new Date();

  weatherData: any = {
    temperature: 'N/A',
    wind: 'N/A',
    type: 'N/A',
    icon: 'N/A',
    cloud: 'N/A'
  }

  constructor(
    private weatherService: WeatherService,
  ) {
    this.subcription = new Subscription()
  }

  ngOnInit() {
    this.cityCTRL.setValue('Surat')
    this.getWeatherByCityName('Surat')
    this.getWeeklyWeatherByKey(202441)

    this.cityCTRL.valueChanges.pipe(debounceTime(1000), distinctUntilChanged()).subscribe((city) => {
      if (city) {
        this.getWeatherByCityName(city)
      }
    })
  }

  ngOnDestroy(): void {
    this.subcription.unsubscribe()
  }

  detectDayNight(weather?: any): string {
    const date = moment().format('HH')
    if (Number(date) >= 18) {
      this.dayNight = 'night'
      return this.dayNight
    }
    else {
      this.dayNight = 'day'
      return this.dayNight
    }
  }

  getWeatherByCityName(cityName: string) {
    const weatherSub = this.weatherService.getWeatherForCity(cityName).subscribe((res: getWeatherForCityModel[]) => {
      this.allCities = res
    })
    this.subcription.add(weatherSub)
  }

  getWeeklyWeatherByKey(cityKey: number) {
    const weatherSub = this.weatherService.getWeeklyWeatherForCity(cityKey).subscribe((res: getWeeklyWeatherForCityModel[]) => {
      this.weeklyWeather = res
      this.weeklyWeatherData = res
      this.dayNight = this.detectDayNight()

      this.weeklyWeather.map((weather: any, i) => {
        if (i === 0) {
          this.weatherDaySelection(weather)
          this.isActiveSelection(weather)
        }
      })
    })
    this.subcription.add(weatherSub)
  }

  getSelectedCity(cityKey: number = 0) {
    this.getWeeklyWeatherByKey(cityKey)
  }

  weatherDaySelection(weather: any) {
    this.selectedWeather = weather
    this.weatherData = {
      temperature: weather.temperature.minValue,
      wind: weather[this.dayNight].windSpeed,
      type: weather[this.dayNight].iconPhrase,
      icon: weather[this.dayNight].icon,
      cloud: weather[this.dayNight].cloudCover
    }
  }

  isActiveSelection(weather: any): any {
    return this.selectedWeather === weather
  }

  celsiusToFahrenhei(unit: boolean) {
    this.weeklyWeatherData = this.weeklyWeather.map((weather: any) => {
      if (unit) {
        weather.temperature.minValue = (weather.temperature.minValue * 9.0 / 5.0) + 32;
        weather.temperature.maxValue = (weather.temperature.maxValue * 9.0 / 5.0) + 32;
        this.weatherData.temperature = weather.temperature.minValue;
      } else {
        weather.temperature.minValue = (weather.temperature.minValue - 32) * 5 / 9
        weather.temperature.maxValue = (weather.temperature.maxValue - 32) * 5 / 9
        this.weatherData.temperature = weather.temperature.minValue
      }
      return weather
    })
  }
}

