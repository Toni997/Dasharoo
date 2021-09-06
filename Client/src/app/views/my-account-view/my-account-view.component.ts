import './my-account-view.component.scss';

export class MyAccountViewController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const MyAccountViewComponent: ng.IComponentOptions = {
  template  : require('./my-account-view.component.html').default,
  controller: MyAccountViewController
};
