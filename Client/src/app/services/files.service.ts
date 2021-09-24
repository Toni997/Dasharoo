export class FilesService {
  RECORD_IMAGE: string;
  RECORD_SOURCE: string;
  PLAYLIST_IMAGE: string;
  PLAYLIST_BACKGROUND: string;
  ACCOUNT_IMAGE: string;
  ACCOUNT_BACKGROUND: string;

  constructor(CONFIG) {
    "ngInject";
    const FILES_ENDPOINT = CONFIG.BASE_URL + "Files/";

    this.RECORD_IMAGE = FILES_ENDPOINT + "Records/Images?source=";
    this.RECORD_SOURCE = FILES_ENDPOINT + "Records/Sources?source=";

    this.PLAYLIST_IMAGE = FILES_ENDPOINT + "Playlists/Images?source=";
    this.PLAYLIST_BACKGROUND = FILES_ENDPOINT + "Playlists/Backgrounds?source=";

    this.ACCOUNT_IMAGE = FILES_ENDPOINT + "Accounts/Images?source=";
    this.ACCOUNT_BACKGROUND = FILES_ENDPOINT + "Accounts/Backgrounds?source=";
  }
}
