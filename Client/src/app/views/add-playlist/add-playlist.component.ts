// import PlaylistModel from "app/data/playlist.model";
import { StateService } from "@uirouter/core";
import { PlaylistsService } from "app/services/playlists.service";
import "./add-playlist.component.scss";

export class AddPlaylistController {
  $state: StateService;
  isSaving: boolean = false;
  playlistsService: PlaylistsService;
  image: any;
  background: any;
  name: string;
  description: string;
  releaseDate: Date;
  visibilityId: string = "1";
  formData: FormData = new FormData();
  constructor(playlistsService: PlaylistsService, $state: StateService) {
    "ngInject";

    this.$state = $state;
    this.playlistsService = playlistsService;
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
    const playlist = await this.playlistsService.postOne(this.formData);
    this.isSaving = false;
    this.$state.go("playlist-details", { id: playlist.id });
  }
}

export const AddPlaylistComponent: ng.IComponentOptions = {
  template: require("./add-playlist.component.html").default,
  controller: AddPlaylistController,
  controllerAs: "APC",
};
