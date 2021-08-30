import "./music-player.component.scss";

export class MusicPlayerController {
  musicPlayer: HTMLAudioElement[];
  timeline: any;
  currentPercentage: number;
  constructor() {
    "ngInject";
  }

  $onInit() {}

  // $scope.$watch()

  changeTime(e: any) {
    const mp: HTMLAudioElement = this.musicPlayer[0];

    // let totalWidth = this.timeline[0].offsetWidth;
    // let offsetWidth = e.offsetX;
    // this.currentPercentage = (offsetWidth / totalWidth) * 100;

    mp.currentTime = (this.currentPercentage / 100) * mp.duration;
  }

  playOrPause() {
    const mp: HTMLAudioElement = this.musicPlayer[0];
    if (mp.paused) mp.play();
    else mp.pause();
  }
}

export const MusicPlayerComponent: ng.IComponentOptions = {
  template: require("./music-player.component.html").default,
  controller: MusicPlayerController,
};
