import { IAngularEvent, IDocumentService } from "angular";
import { ReduxService } from "app/services/redux.service";
import "./queue.component.scss";

export class QueueController {
  redux: any;
  $scope: any;
  reduxService: ReduxService;
  dispatch: any;
  audioElement: HTMLAudioElement;
  $document: IDocumentService;
  $rootScope: ng.IRootScopeService;
  playPauseEvent: any;

  constructor(
    $document: IDocumentService,
    $ngRedux,
    $scope: any,
    reduxService: ReduxService,
    $rootScope: ng.IRootScopeService
  ) {
    "ngInject";

    this.$rootScope = $rootScope;
    this.$document = $document;

    this.$scope = $scope;
    this.redux = $ngRedux;
    this.reduxService = reduxService;
    this.dispatch = this.reduxService.dispatch();
    this.$scope.recordsState = this.redux.getState().records;
  }

  $onInit() {
    this.redux.subscribe(() => {
      this.$scope.recordsState = this.redux.getState().records;
    });

    // toggle bars animation play state on audio paused change
    this.audioElement = this.$document[0].querySelector("audio");
    this.$scope.$on(
      "playPauseEvent",
      (event: IAngularEvent, isPaused: boolean) => {
        console.log(event);
        const first = this.$document[0].getElementById("first");
        const second = this.$document[0].getElementById("second");
        const third = this.$document[0].getElementById("third");
        first.style.animationPlayState = isPaused ? "paused" : "running";
        second.style.animationPlayState = isPaused ? "paused" : "running";
        third.style.animationPlayState = isPaused ? "paused" : "running";
      }
    );
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
