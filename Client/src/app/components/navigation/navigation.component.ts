import './navigation.component.scss';

export class NavigationController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const NavigationComponent: ng.IComponentOptions = {
  template  : require('./navigation.component.html').default,
  controller: NavigationController
};
