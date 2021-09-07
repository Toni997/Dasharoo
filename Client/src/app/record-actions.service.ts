import {
  RECORDS_FAIL,
  RECORDS_REQUEST,
  RECORDS_SUCCESS,
} from "./constants/recordConstants";
import { RecordsService } from "./records.service";

export class RecordActionsService {
  recordsService: RecordsService;
  constructor(recordsService: RecordsService) {
    "ngInject";

    this.recordsService = recordsService;
  }
  listProducts() {
    const self = this;
    return async function (dispatch) {
      try {
        dispatch({ type: RECORDS_REQUEST });

        const data = await self.recordsService.getAll();

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
