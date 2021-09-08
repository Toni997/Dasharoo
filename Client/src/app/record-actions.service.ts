import {
  RECORDS_FAIL,
  RECORDS_REQUEST,
  RECORDS_SUCCESS,
} from "./constants/recordConstants";
import QueueAddType from "./queueAddType.enum";
import { RecordsService } from "./records.service";
import { PlaylistsService } from "./services/playlists.service";

export class RecordActionsService {
  recordsService: RecordsService;
  playlistsService: PlaylistsService;

  constructor(
    recordsService: RecordsService,
    playlistsService: PlaylistsService
  ) {
    "ngInject";

    this.recordsService = recordsService;
    this.playlistsService = playlistsService;
  }

  addToQueue(id: number, type: QueueAddType = null) {
    const self = this;
    return async function (dispatch) {
      try {
        dispatch({ type: RECORDS_REQUEST });
        let data = null;
        switch (type) {
          case QueueAddType.Playlist:
            data = await self.playlistsService.getOne(id);
            data = data.records;
            console.log(data);
            break;
          case QueueAddType.Record:
            data = await self.recordsService.getOne(id);
            data = [data];
            break;
          default:
            return;
        }

        dispatch({ type: RECORDS_SUCCESS, payload: data });
      } catch (error) {
        dispatch({
          type: RECORDS_FAIL,
          payload:
            error.response && error.response.data.message
              ? error.response.data.message
              : error.message,
        });
      }
    };
  }
}
