import * as angular from 'angular';

import '../vendor';

import { AppConfig } from './app.config';
import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';

let module: ng.IModule = angular.module('dasharoo', [
  'ngAnimate',
  'ngResource',
  'ngSanitize',
  'ngMessages',
  'ngAria',
  'ngCookies',
  'ui.router',
  'restangular',
  'oc.lazyLoad'
]);

module.constant('ENVIRONMENT', ENV);
module.constant('CONFIG', CONFIG);

module.config(AppConfig);
module.config(AppRoutes);

module.component('app', AppComponent);

export const AppModule = module.name;
