import './loader.component.scss';

export class LoaderController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const LoaderComponent: ng.IComponentOptions = {
  template  : require('./loader.component.html').default,
  controller: LoaderController
};
