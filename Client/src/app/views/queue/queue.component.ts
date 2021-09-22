import "./queue.component.scss";

export class QueueController {
  redux: any;
  $scope: any;

  constructor($ngRedux, $scope: any) {
    "ngInject";
    this.redux = $ngRedux;
    this.$scope = $scope;
    const queueFromRedux = this.redux.getState().records.queue;
    console.log(queueFromRedux);
    this.$scope.queue = queueFromRedux ? queueFromRedux : null;
  }

  $postLink() {}
}

export const QueueComponent: ng.IComponentOptions = {
  template: require("./queue.component.html").default,
  controller: QueueController,
  controllerAs: "QC",
};
