import './quick-play.component.scss';

export class QuickPlayController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const QuickPlayComponent: ng.IComponentOptions = {
  template  : require('./quick-play.component.html').default,
  controller: QuickPlayController
};
