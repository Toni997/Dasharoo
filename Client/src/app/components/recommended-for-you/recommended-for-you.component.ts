import './recommended-for-you.component.scss';

export class RecommendedForYouController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const RecommendedForYouComponent: ng.IComponentOptions = {
  template  : require('./recommended-for-you.component.html').default,
  controller: RecommendedForYouController
};
