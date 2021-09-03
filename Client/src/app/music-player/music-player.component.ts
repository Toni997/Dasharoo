import { RecordActionsService } from "app/record-actions.service";
import { RecordsService } from "app/records.service";
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
  recordsService: RecordsService;
  recordActions: RecordActionsService;
  records: any;
  $scope: any;
  currentRecordIndex: number = 0;

  constructor(
    $scope: any,
    $ngRedux: any,
    recordsService: RecordsService,
    recordActionsService: RecordActionsService
  ) {
    ("ngInject");

    this.$scope = $scope;
    this.redux = $ngRedux;
    this.recordsService = recordsService;
    this.recordActions = recordActionsService;
    this.$scope.queue = null;
    this.redux.subscribe(() => {
      this.$scope.records = this.redux.getState().records;
      this.$scope.$apply();
      console.log($scope.records);
    });
  }
  async $onInit() {
    // this.redux.dispatch(this.recordActions.listRecords());
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

  onEnded() {
    this.centerButtonIcon = "play";
  }

  changeTime(e: any) {
    if (!this.mp.src) return;

    let totalWidth = this.timeline[0].offsetWidth;
    let offsetWidth = e.offsetX;
    this.currentPercentage = (offsetWidth / totalWidth) * 100;
    this.mp.currentTime = (this.currentPercentage / 100) * this.mp.duration;
  }

  playOrPause() {
    if (!this.mp.src) return;
    if (this.mp.paused) {
      this.mp.play();
      this.centerButtonIcon = "pause";
      this.playButtonTooltip = "Pause";
    } else {
      this.mp.pause();
      this.centerButtonIcon = "play";
      this.playButtonTooltip = "Play";
    }
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

  changeVolume(e: any) {
    let totalWidth = this.volumeBar[0].offsetWidth;
    let offsetWidth = e.offsetX;
    this.mp.volume = offsetWidth / totalWidth;
  }

  loop(e: any) {
    const el: HTMLImageElement = e.target;
    if (this.mp.loop) {
      this.mp.loop = false;
      el.classList.remove("control-selected");
    } else {
      this.mp.loop = true;
      el.classList.add("control-selected");
    }
  }
}

export const MusicPlayerComponent: ng.IComponentOptions = {
  template: require("./music-player.component.html").default,
  controller: MusicPlayerController,
};
