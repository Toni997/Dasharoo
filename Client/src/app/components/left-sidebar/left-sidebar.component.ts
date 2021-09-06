import "./left-sidebar.component.scss";

export class LeftSidebarController {
  $document: ng.IDocumentService;

  constructor($document: ng.IDocumentService) {
    "ngInject";

    this.$document = $document;
  }

  $onInit() {}

  closeLeftSidebar() {
    const uiView: any = this.$document.find("ui-view")[0];
    const leftSidebar: any = this.$document.find("left-sidebar")[0];

    uiView.classList.add("margin-left-0");
    leftSidebar.classList.add("hide-sidebar");
    // uiView.classList.remove("margin-left-sidebarWidth");
    leftSidebar.classList.remove("show-sidebar");
  }
}

export const LeftSidebarComponent: ng.IComponentOptions = {
  template: require("./left-sidebar.component.html").default,
  controller: LeftSidebarController,
};
