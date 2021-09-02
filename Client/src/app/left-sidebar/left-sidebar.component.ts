import './left-sidebar.component.scss';

export class LeftSidebarController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const LeftSidebarComponent: ng.IComponentOptions = {
  template  : require('./left-sidebar.component.html').default,
  controller: LeftSidebarController
};
