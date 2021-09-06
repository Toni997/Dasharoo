import './search-view.component.scss';

export class SearchViewController {

  constructor () { 'ngInject'; }

  $onInit () {}

}

export const SearchViewComponent: ng.IComponentOptions = {
  template  : require('./search-view.component.html').default,
  controller: SearchViewController
};
