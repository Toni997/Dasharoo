import { RecordsService } from "app/records.service";

import {
  RECORDS_FAIL,
  RECORDS_REQUEST,
  RECORDS_SUCCESS,
} from "../constants/recordConstants";

export class RecordActions {
  recordsService: RecordsService;

  constructor(recordsService: RecordsService) {
    "ngInject";

    this.recordsService = recordsService;
  }

  listRecords() {
    return async function (dispatch) {
      try {
        dispatch({ type: RECORDS_REQUEST });

        console.log("ajaj", this.recordsService);
        const data = await this.recordsService.getAll();

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

// export const listProductDetails = (id) => async (dispatch) => {
//   try {
//     dispatch({ type: RECORDS_REQUEST });

//     const { data } = await axios.get(`/api/products/${id}`);

//     dispatch({ type: RECORDS_SUCCESS, payload: data });
//   } catch (error) {
//     dispatch({
//       type: RECORDS_FAIL,
//       payload:
//         error.response && error.response.data.message
//           ? error.response.data.message
//           : error.message,
//     });
//   }
// };
