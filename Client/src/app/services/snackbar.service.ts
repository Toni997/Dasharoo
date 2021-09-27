import angular, { IDocumentService } from "angular";

export class SnackbarService {
  private $document: IDocumentService;

  constructor($document: IDocumentService) {
    "ngInject";

    this.$document = $document;
  }

  open(message: string) {
    // const body: HTMLElement = this.$document.find("ui-view")[0];
    // const snackbar: HTMLElement = this.$document[0].createElement("snackbar");
    // snackbar.setAttribute("message", message);
    // body.appendChild(snackbar);
    console.log(angular.element("body"));
  }
}
