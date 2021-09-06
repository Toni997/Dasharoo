import "./home-header.component.scss";

export class HomeHeaderController {
  $document: ng.IDocumentService;

  constructor($document: ng.IDocumentService) {
    "ngInject";

    this.$document = $document;
  }

  $onInit() {}

  showLeftSidebar() {
    const uiView: any = this.$document.find("ui-view")[0];
    const leftSidebar: any = this.$document.find("left-sidebar")[0];
    console.log(uiView, leftSidebar);

    // uiView.classList.add("margin-left-sidebarWidth");
    leftSidebar.classList.add("show-sidebar");
    // uiView.classList.remove("margin-left-0");
    leftSidebar.classList.remove("hide-sidebar");
  }
}

export const HomeHeaderComponent: ng.IComponentOptions = {
  template: require("./home-header.component.html").default,
  controller: HomeHeaderController,
};
