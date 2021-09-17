import "./dinput.component.scss";

export class DinputController {
  icon: string;
  placeholder: string;
  type: string;
  bindto: any;
  required: boolean;
  min: number;
  max: number;

  constructor() {
    "ngInject";
  }

  $onInit() {}
}

export const DinputComponent: ng.IComponentOptions = {
  template: require("./dinput.component.html").default,
  controller: DinputController,
  bindings: {
    icon: "@",
    placeholder: "@",
    text: "@",
    type: "@",
    bindto: "=",
    required: "<",
    min: "<",
    max: "<",
  },
};
