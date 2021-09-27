import "./snackbar.component.scss";

export class SnackbarController {
  message: string;

  constructor() {
    "ngInject";
  }

  $onInit() {
    console.log("message is", this.message);
  }
}

export const SnackbarComponent: ng.IComponentOptions = {
  template: require("./snackbar.component.html").default,
  controller: SnackbarController,
  controllerAs: "SBC",
  bindings: {
    message: "@",
  },
};
