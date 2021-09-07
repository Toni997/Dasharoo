import {
  RECORDS_REQUEST,
  RECORDS_SUCCESS,
  RECORDS_FAIL,
  RECORDS_RESET,
} from "../constants/recordConstants";

export const queueReducer = (state = { queue: [] }, action) => {
  switch (action.type) {
    case RECORDS_REQUEST:
      return { loading: true, queue: [...state.queue] };
    case RECORDS_SUCCESS:
      return { loading: false, queue: [...state.queue, ...action.payload] };
    case RECORDS_FAIL:
      return { loading: false, error: action.payload };
    case RECORDS_RESET:
      return { queue: [] };
    default:
      return state;
  }
};
