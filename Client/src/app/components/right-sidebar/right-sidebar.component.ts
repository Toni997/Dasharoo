import './right-sidebar.component.scss';

export class RightSidebarController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const RightSidebarComponent: ng.IComponentOptions = {
  template  : require('./right-sidebar.component.html').default,
  controller: RightSidebarController
};
