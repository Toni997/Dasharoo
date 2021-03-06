import { ILocationService } from "angular";
import { SidebarsService } from "app/services/sidebars.service";

import "./navigation.component.scss";

export class NavigationController {
  $location: ILocationService;
  currentPath: string;
  $scope: any;
  sidebarsService: SidebarsService;
  closeLeftSidebar: any;

  constructor(
    $scope: any,
    $location: ILocationService,
    sidebarsService: SidebarsService
  ) {
    "ngInject";

    this.$scope = $scope;
    this.$location = $location;
    this.sidebarsService = sidebarsService;
    this.closeLeftSidebar = this.sidebarsService.useCloseLeftSidebar();
  }

  $onInit() {}
}

export const NavigationComponent: ng.IComponentOptions = {
  template: require("./navigation.component.html").default,
  controller: NavigationController,
};
