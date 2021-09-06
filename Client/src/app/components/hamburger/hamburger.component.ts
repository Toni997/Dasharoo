import "./hamburger.component.scss";

export class HamburgerController {
  $document: ng.IDocumentService;
  constructor($document: ng.IDocumentService) {
    "ngInject";

    this.$document = $document;
  }

  $onInit() {}

  toggleLeftSidebar() {
    const uiView: any = this.$document.find("ui-view")[0];
    const leftSidebar: any = this.$document.find("left-sidebar")[0];
    console.log(uiView, leftSidebar);

    leftSidebar.classList.add("show-sidebar");
    leftSidebar.classList.remove("hide-sidebar");
  }
}

export const HamburgerComponent: ng.IComponentOptions = {
  template: require("./hamburger.component.html").default,
  controller: HamburgerController,
};
