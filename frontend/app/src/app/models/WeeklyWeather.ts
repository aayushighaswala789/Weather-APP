
export interface getWeeklyWeatherForCityModel {
  id: string;
  locationName: string;
  forecastDate: string;
  temperature: {
    id: string;
    minValue: number;
    maxValue: number;
    phraseForMin: string;
    phraseForMax: string;
    unitOfMeasure: string;
  },
  realFeelTemperature: {
    id: string;
    minValue: number;
    maxValue: number;
    phraseForMin: string;
    phraseForMax: string;
    unitOfMeasure: string;
  },
  day: {
    id: string;
    icon: number;
    iconPhrase: string;
    windSpeed: number;
    windSpeedUnitOfMeasure: string;
  },
  night: {
    id: string;
    icon: number;
    iconPhrase: string;
    windSpeed: number;
    windSpeedUnitOfMeasure: string;
  }
}
