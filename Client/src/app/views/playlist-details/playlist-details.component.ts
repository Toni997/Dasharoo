import { StateParams, StateService } from "@uirouter/core";
import { IAngularEvent, IDocumentService } from "angular";
import { PlaylistsService } from "app/services/playlists.service";
import { ReduxService } from "app/services/redux.service";
import { SnackbarService } from "app/services/snackbar.service";
import "./playlist-details.component.scss";

export class PlaylistDetailsController {
  $scope: any;
  $state: StateService;
  reduxService: ReduxService;
  dispatch: any;
  playlistsService: PlaylistsService;
  playlist: any;
  playlistImage: HTMLImageElement[];
  playlistId: number;
  artistImage: HTMLImageElement[];
  redux: any;
  isCurrentlyPlaying: boolean = false;
  $document: IDocumentService;
  audioElement: HTMLAudioElement;
  shouldShowActionMenu: boolean = false;
  snackbarService: SnackbarService;

  constructor(
    $document: IDocumentService,
    $scope: any,
    $state: StateService,
    $stateParams: StateParams,
    playlistsService: PlaylistsService,
    snackbarService: SnackbarService,
    reduxService: ReduxService,
    $ngRedux: any
  ) {
    "ngInject";

    this.$document = $document;
    this.$scope = $scope;
    this.$state = $state;

    this.playlistId = parseInt($stateParams.id);
    this.playlistsService = playlistsService;
    this.snackbarService = snackbarService;
    this.redux = $ngRedux;
    this.reduxService = reduxService;
    this.$scope.recordsState = this.redux.getState().records;
    this.isCurrentlyPlaying =
      this.$scope.recordsState.queue !== null &&
      this.$scope.recordsState.queue.id === this.playlistId;
    this.redux.subscribe(() => {
      this.$scope.recordsState = this.redux.getState().records;
      this.isCurrentlyPlaying =
        this.$scope.recordsState.queue !== null &&
        this.$scope.recordsState.queue.id === this.playlistId;
    });
  }

  async $onInit() {
    this.playlist = await this.playlistsService.getOne(this.playlistId);
    this.playlist.recordPlaylists.forEach((rp) => {
      this.playlist.records.push(rp.record);
    });
    console.log(this.playlist);
    this.playlist.releaseYear = new Date(
      this.playlist.releaseDate
    ).getFullYear();

    this.$scope.$apply();
    this.dispatch = this.reduxService.dispatch();
    this.playlistImage[0].src =
      "https://localhost:44350/api/Files/Playlists/Images?source=" +
      this.playlist.imagePath;

    this.artistImage[0].src =
      "https://localhost:44350/api/Files/Accounts/Images?source=" +
      this.playlist.author.imagePath;

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

  async onPlay(index: number = 0) {
    if (!this.isCurrentlyPlaying)
      await this.dispatch.addToQueue(this.playlistId, index);
  }

  async onPlayRecord(index: number) {
    if (!this.isCurrentlyPlaying)
      await this.dispatch.addToQueue(this.playlistId, index);
    else {
      await this.dispatch.changeIndex(index);
    }
  }

  async onDelete() {
    try {
      await this.playlistsService.deleteOne(this.playlistId);
      this.snackbarService.open("Successfully deleted");
      this.$state.go("app");
    } catch (error) {
      this.snackbarService.open("Could not delete!");
    }
  }
}

export const PlaylistDetailsComponent: ng.IComponentOptions = {
  template: require("./playlist-details.component.html").default,
  controller: PlaylistDetailsController,
  controllerAs: "PDC",
};
