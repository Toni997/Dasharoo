import './home-header.component.scss';

export class HomeHeaderController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const HomeHeaderComponent: ng.IComponentOptions = {
  template  : require('./home-header.component.html').default,
  controller: HomeHeaderController
};
