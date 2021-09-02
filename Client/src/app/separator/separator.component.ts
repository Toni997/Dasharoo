import "./separator.component.scss";

export class SeparatorController {
  text: string;

  constructor() {
    "ngInject";
  }

  $onInit() {}
}

export const SeparatorComponent: ng.IComponentOptions = {
  template: require("./separator.component.html").default,
  controller: SeparatorController,
  bindings: {
    text: "<",
  },
};
