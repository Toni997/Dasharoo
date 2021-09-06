export class SidebarsService {
  $document: ng.IDocumentService;

  constructor($document: ng.IDocumentService) {
    "ngInject";

    this.$document = $document;
  }

  useCloseLeftSidebar() {
    return () => {
      const uiView: any = this.$document.find("ui-view")[0];
      const leftSidebar: any = this.$document.find("left-sidebar")[0];

      uiView.classList.add("margin-left-0");
      leftSidebar.classList.add("hide-sidebar");
      // uiView.classList.remove("margin-left-sidebarWidth");
      leftSidebar.classList.remove("show-sidebar");
    };
  }
}
