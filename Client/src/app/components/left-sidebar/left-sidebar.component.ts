import { SidebarsService } from "app/services/sidebars.service";
import "./left-sidebar.component.scss";

export class LeftSidebarController {
  $document: ng.IDocumentService;
  sidebarsService: SidebarsService;
  closeLeftSidebar: any;

  constructor(
    $document: ng.IDocumentService,
    sidebarsService: SidebarsService
  ) {
    "ngInject";

    this.sidebarsService = sidebarsService;
    this.$document = $document;

    this.closeLeftSidebar = this.sidebarsService.useCloseLeftSidebar();
  }

  $onInit() {
    console.log(this.$document.find("navigation")[0]);
  }
}

export const LeftSidebarComponent: ng.IComponentOptions = {
  template: require("./left-sidebar.component.html").default,
  controller: LeftSidebarController,
};
