import {
  RECORDS_FAIL,
  RECORDS_REQUEST,
  RECORDS_SUCCESS,
  QUEUE_INDEX_CHANGE,
} from "../constants/recordConstants";
import { RecordsService } from "../records.service";
import { PlaylistsService } from "../services/playlists.service";

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

  changeIndex(newIndex: number) {
    return async function (dispatch) {
      dispatch({ type: QUEUE_INDEX_CHANGE, payload: newIndex });
    };
  }

  addToQueue(id: number) {
    const self = this;
    return async function (dispatch) {
      try {
        dispatch({ type: RECORDS_REQUEST });
        let data = await self.playlistsService.getOneForQueue(id);

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
