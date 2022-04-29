export interface getWeatherForCityModel {
  key?: number;
  localizedName: string;
  country: {
    id: string;
    localizedName: string;
  },
  administrativeArea: {
    id: string;
    localizedName: string;
  }
}
