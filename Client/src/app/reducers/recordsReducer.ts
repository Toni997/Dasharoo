import {
  RECORDS_REQUEST,
  RECORDS_SUCCESS,
  RECORDS_FAIL,
  RECORDS_RESET,
  QUEUE_INDEX_CHANGE,
} from "../constants/recordConstants";

export const recordsReducer = (
  state = { loading: false, index: 0, queue: null },
  action
) => {
  switch (action.type) {
    case RECORDS_REQUEST:
      return { loading: true, index: 0, queue: state.queue };
    case RECORDS_SUCCESS:
      return {
        loading: false,
        index: 0,
        queue: action.payload,
      };
    case RECORDS_FAIL:
      return { loading: false, index: 0, queue: null, error: action.payload };
    case RECORDS_RESET:
      return { loading: false, index: 0, queue: null };
    case QUEUE_INDEX_CHANGE:
      return { loading: false, index: action.payload, queue: state.queue };
    default:
      return state;
  }
};
