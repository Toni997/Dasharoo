// import PlaylistModel from "app/data/playlist.model";
import { StateService } from "@uirouter/core";
import { PlaylistsService } from "app/services/playlists.service";
import { SnackbarService } from "app/services/snackbar.service";
import "./add-playlist.component.scss";

export class AddPlaylistController {
  $state: StateService;
  isSaving: boolean = false;
  playlistsService: PlaylistsService;
  snackbarService: SnackbarService;
  image: any;
  background: any;
  name: string;
  description: string;
  releaseDate: Date;
  visibilityId: string = "1";
  formData: FormData = new FormData();
  constructor(
    playlistsService: PlaylistsService,
    $state: StateService,
    snackbarService: SnackbarService
  ) {
    "ngInject";

    this.$state = $state;
    this.playlistsService = playlistsService;
    this.snackbarService = snackbarService;
  }

  $onInit() {}

  async onSubmit() {
    if (!this.releaseDate) this.releaseDate = new Date();
    this.formData.append("name", this.name);
    this.formData.append("description", this.description);
    this.formData.append("visibilityId", this.visibilityId);
    this.formData.append("releaseDate", this.releaseDate.toJSON());
    this.image[0].files.length > 0 &&
      this.formData.append("image", this.image[0].files[0], "image.jpg");
    this.background[0].files.length > 0 &&
      this.formData.append(
        "background",
        this.background[0].files[0],
        "background.jpg"
      );
    this.isSaving = true;
    this.playlistsService.postOne(this.formData).then((playlist) => {
      this.isSaving = false;
      this.snackbarService.open("Playlist successfully created");
      this.$state.go("playlist-details", { id: playlist.id });
    });
  }
}

export const AddPlaylistComponent: ng.IComponentOptions = {
  template: require("./add-playlist.component.html").default,
  controller: AddPlaylistController,
  controllerAs: "APC",
};
