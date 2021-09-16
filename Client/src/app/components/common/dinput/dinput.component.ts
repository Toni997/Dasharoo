import "./dinput.component.scss";

export class DinputController {
  iconName: string = "search";
  placeholder: string = "";
  type: string = "text";

  constructor() {
    "ngInject";
  }

  $onInit() {
    console.log(this.type);
  }
}

export const DinputComponent: ng.IComponentOptions = {
  template: require("./dinput.component.html").default,
  controller: DinputController,
  bindings: {
    placeholder: "@",
    text: "@",
    type: "@",
  },
};
