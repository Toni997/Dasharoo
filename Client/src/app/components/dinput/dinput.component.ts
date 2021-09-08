import './dinput.component.scss';

export class DinputController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const DinputComponent: ng.IComponentOptions = {
  template  : require('./dinput.component.html').default,
  controller: DinputController
};
