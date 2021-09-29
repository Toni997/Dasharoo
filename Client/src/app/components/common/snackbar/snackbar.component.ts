import "./snackbar.component.scss";

export class SnackbarController {
  message: string;
  type: "success" | "error";

  constructor() {
    "ngInject";
  }

  $onInit() {}

  removeSelf() {
    console.log("should remove");
  }
}

export const SnackbarComponent: ng.IComponentOptions = {
  template: require("./snackbar.component.html").default,
  controller: SnackbarController,
  controllerAs: "SBC",
  bindings: {
    message: "@",
    type: "@",
  },
};
