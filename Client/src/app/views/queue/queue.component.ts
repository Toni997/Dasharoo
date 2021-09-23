import { ReduxService } from "app/services/redux.service";
import "./queue.component.scss";

export class QueueController {
  redux: any;
  $scope: any;
  reduxService: ReduxService;
  dispatch: any;

  constructor($ngRedux, $scope: any, reduxService: ReduxService) {
    "ngInject";
    this.redux = $ngRedux;
    this.$scope = $scope;
    this.reduxService = reduxService;
    this.dispatch = this.reduxService.dispatch();
    this.$scope.recordsState = this.redux.getState().records;
  }

  $onInit() {
    this.redux.subscribe(() => {
      this.$scope.recordsState = this.redux.getState().records;
      console.log("state", this.$scope.recordsState);
    });
  }

  onPlayRecord(newIndex: number) {
    this.dispatch.changeIndex(newIndex);
  }
}

export const QueueComponent: ng.IComponentOptions = {
  template: require("./queue.component.html").default,
  controller: QueueController,
  controllerAs: "QC",
};
