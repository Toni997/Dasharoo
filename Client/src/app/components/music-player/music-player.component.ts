import { IDocumentService } from "angular";
import { RecordActionsService } from "app/actions/record-actions.service";
import { RecordsService } from "app/records.service";
import { AuthService } from "app/services/auth.service";
import { ReduxService } from "app/services/redux.service";
import "./music-player.component.scss";

export class MusicPlayerController {
  musicPlayerRef: HTMLAudioElement[];
  mp: HTMLAudioElement;
  timeline: HTMLDivElement[];
  centerButtonIcon: "play" | "pause" = "play";
  currentPercentage: number = 0;
  volumeBar: HTMLDivElement[];
  volumeBarContainer: HTMLDivElement[];
  currentTime = 0;
  duration = 0;
  currentTimeString = "0:00";
  durationString = "0:00";
  scrubBar: HTMLDivElement[];
  volumeProgressBar: HTMLDivElement[];
  circleTimeline: HTMLDivElement[];
  circleVolume: HTMLDivElement[];
  dragStartX: number;
  dragStartVolume: number;
  volumeIcon: "volume-mid" | "muted" = "volume-mid";
  playButtonTooltip: "Play" | "Pause" = "Play";
  redux;
  reduxService: ReduxService;
  dispatch: any;
  recordsService: RecordsService;
  recordActions: RecordActionsService;
  records: any;
  $scope: any;
  self;
  config;
  audioPath: string;
  imagePath: string;
  currentQueueIndex: number = 0;
  shuffleEnabled: boolean = false;
  authService: AuthService;
  $document: IDocumentService;

  constructor(
    $scope: any,
    $ngRedux: any,
    reduxService: ReduxService,
    recordsService: RecordsService,
    recordActionsService: RecordActionsService,
    authService: AuthService,
    $document: IDocumentService,
    CONFIG
  ) {
    ("ngInject");

    this.$document = $document;

    this.reduxService = reduxService;
    this.dispatch = this.reduxService.dispatch();

    this.config = CONFIG;
    this.audioPath = this.config.BASE_URL + "Files/Records/Sources?source=";
    this.imagePath = this.config.BASE_URL + "Files/Records/Images?source=";

    this.$scope = $scope;
    this.authService = authService;
    this.redux = $ngRedux;
    this.recordsService = recordsService;
    this.recordActions = recordActionsService;
    this.redux.subscribe(() => {
      this.$scope.recordsState = this.redux.getState().records;
      this.currentQueueIndex = this.$scope.recordsState.index;
      if (this.$scope.recordsState && this.$scope.recordsState.queue !== null)
        this.updateMusicPlayer();
    });
  }
  async $onInit() {
    this.$scope.recordTitle = "No music in queue";
    this.$scope.recordAuthors = "Dasharoo";
    this.$scope.recordSrc = "";
    this.$scope.recordImage = this.imagePath + "no-image.png";

    this.$scope.$watch("$ctrl.mp.paused", () => {
      this.centerButtonIcon = this.mp.paused ? "play" : "pause";
      this.playButtonTooltip = this.mp.paused ? "Play" : "Pause";
    });
  }

  $postLink() {
    this.mp = this.musicPlayerRef[0];
  }

  updateRecord() {
    // this.mp.currentTime = this.scrubBar[0].value;
  }

  showCircleTimeline() {
    this.circleTimeline[0].classList.remove("display-none");
    this.circleTimeline[0].classList.add("display-block");
  }

  hideCircleTimeline() {
    this.circleTimeline[0].classList.remove("display-block");
    this.circleTimeline[0].classList.add("display-none");
  }

  doNothing(e: any) {
    e.preventDefault();
    e.stopPropagation();
  }

  timeToString(time: number) {
    let seconds = time;
    let hours = 0;
    let minutes = 0;
    while (seconds >= 3600) {
      seconds -= 3600;
      hours++;
    }
    while (seconds >= 60) {
      seconds -= 60;
      minutes++;
    }
    if (hours === 0) {
      return minutes + ":" + (seconds < 10 ? "0" + seconds : seconds);
    }
    return (
      hours +
      ":" +
      (minutes < 10 ? "0" + minutes : minutes) +
      ":" +
      (seconds < 10 ? "0" + seconds : seconds)
    );
  }

  updateProgressBar() {
    this.currentPercentage = (this.mp.currentTime / this.mp.duration) * 100;
    let currentTime = Math.floor(this.mp.currentTime);
    let duration = Math.floor(this.mp.duration);
    if (this.currentTime !== currentTime) {
      this.currentTimeString = this.timeToString(currentTime);
      this.currentTime = currentTime;
    }
    if (this.duration !== duration) {
      this.durationString = this.timeToString(duration);
      this.duration = duration;
    }
  }

  onRecordEnded() {
    if (!this.shuffleEnabled) this.playNext();
    else this.playRandom();
  }

  playRandom() {
    if (!this.$scope.recordsState || this.$scope.recordsState.queue === null)
      return;

    const oldIndex = this.currentQueueIndex;
    do {
      this.currentQueueIndex = this.randomNum(
        0,
        this.$scope.recordsState.queue.records.length - 1
      );
    } while (this.currentQueueIndex === oldIndex);

    this.dispatch.changeIndex(this.currentQueueIndex);

    this.updateMusicPlayer();
    this.mp.play();
  }

  playPrevious() {
    if (!this.$scope.recordsState || this.$scope.recordsState.queue === null)
      return;

    if (this.currentQueueIndex !== 0) {
      this.dispatch.changeIndex(--this.currentQueueIndex);
    } else {
      this.dispatch.changeIndex(
        this.$scope.recordsState.queue.records.length - 1
      );
    }

    this.updateMusicPlayer();
    this.mp.play();
  }

  randomNum(min: number, max: number) {
    return Math.floor(Math.random() * (max - min)) + min; // You can remove the Math.floor if you don't want it to be an integer
  }

  playNext() {
    if (!this.$scope.recordsState || this.$scope.recordsState.queue === null)
      return;

    if (
      this.currentQueueIndex !==
      this.$scope.recordsState.queue.records.length - 1
    ) {
      this.dispatch.changeIndex(++this.currentQueueIndex);
    } else {
      this.dispatch.changeIndex(0);
    }

    this.updateMusicPlayer();
    this.mp.play();
  }

  changeTime(e: any) {
    if (!this.mp.src) return;

    let totalWidth = this.timeline[0].offsetWidth;
    let offsetWidth = e.offsetX;
    this.currentPercentage = (offsetWidth / totalWidth) * 100;
    this.mp.currentTime = (this.currentPercentage / 100) * this.mp.duration;
  }

  playOrPause() {
    if (
      this.$scope.recordsState.queue === null ||
      this.$scope.recordsState.queue.records.length === 0
    )
      return;

    let records = this.$scope.recordsState.queue.records;
    if (!this.mp.src) {
      this.mp.src = this.audioPath + records[this.currentQueueIndex].sourcePath;
      this.updateMusicPlayer();
    }
    if (this.mp.paused) {
      this.mp.play();
    } else {
      this.mp.pause();
    }
  }

  updateMusicPlayer() {
    let nextInQueue =
      this.$scope.recordsState.queue.records[this.currentQueueIndex];
    this.$scope.recordTitle = nextInQueue.name;
    this.$scope.recordAuthors = nextInQueue.recordAuthors;
    this.$scope.recordSrc = this.audioPath + nextInQueue.sourcePath;
    this.$scope.recordImage = this.imagePath + nextInQueue.imagePath;
    this.mp.src = this.audioPath + nextInQueue.sourcePath;
    this.mp.play();
  }

  mute() {
    if (this.mp.muted) {
      this.mp.muted = false;
      this.volumeIcon = "volume-mid";
    } else {
      this.mp.muted = true;
      this.volumeIcon = "muted";
    }
  }

  loop() {
    const el: HTMLElement = this.$document[0].querySelector("#loop");

    if (this.mp.loop) {
      this.mp.loop = false;
      el.classList.remove("make-it-green");
    } else {
      this.mp.loop = true;
      el.classList.add("make-it-green");
    }
  }

  shuffle() {
    const el: HTMLElement = this.$document[0].querySelector("#shuffle");
    this.shuffleEnabled = !this.shuffleEnabled;
    if (!this.shuffleEnabled) {
      el.classList.remove("make-it-green");
    } else {
      el.classList.add("make-it-green");
    }
  }
}

export const MusicPlayerComponent: ng.IComponentOptions = {
  template: require("./music-player.component.html").default,
  controller: MusicPlayerController,
};
