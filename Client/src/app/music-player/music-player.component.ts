import "./music-player.component.scss";

export class MusicPlayerController {
  musicPlayerRef: HTMLAudioElement[];
  mp: HTMLAudioElement;
  timeline: HTMLDivElement[];
  centerButtonIcon: "play" | "pause" = "play";
  currentPercentage: number = 0;
  volumeBar: HTMLDivElement[];
  currentTime = 0;
  duration = 0;
  currentTimeString = "0:00";
  durationString = "0:00";
  scrubBar: HTMLDivElement[];
  circle: HTMLDivElement[];
  dragStartX: number;
  dragStartCurrentProgress: number;

  constructor() {
    ("ngInject");
  }

  $onInit() {}

  $postLink() {
    this.musicPlayerRef[0].onloadedmetadata = () => {
      this.mp = this.musicPlayerRef[0];
    };
  }

  updateRecord() {
    // this.mp.currentTime = this.scrubBar[0].value;
  }

  onDragStart(e: any) {
    e.dataTransfer.setData("text/plain", "This text may be dragged");
    e.dataTransfer.dropEffect = "move";
    e.dataTransfer.effectAllowed = "move";
    // e.dataTransfer.setData;
  }

  onDragOver(e: any) {
    console.log(e.target);

    e.target.style.background = "red";

    e.preventDefault();
  }

  showCircle() {
    this.circle[0].classList.remove("display-none");
    this.circle[0].classList.add("display-block");
  }

  hideCircle() {
    this.circle[0].classList.remove("display-block");
    this.circle[0].classList.add("display-none");
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
    let totalWidth = this.timeline[0].offsetWidth;
    let offsetWidth = e.offsetX;
    this.currentPercentage = (offsetWidth / totalWidth) * 100;
    this.mp.currentTime = (this.currentPercentage / 100) * this.mp.duration;
  }

  playOrPause() {
    if (this.mp.paused) {
      this.mp.play();
      this.centerButtonIcon = "pause";
    } else {
      this.mp.pause();
      this.centerButtonIcon = "play";
    }
  }
}

export const MusicPlayerComponent: ng.IComponentOptions = {
  template: require("./music-player.component.html").default,
  controller: MusicPlayerController,
};
