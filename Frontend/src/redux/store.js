import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./userSlice";

// Export the Redux store configuration
export const store = configureStore({
  reducer: {
    user: userReducer,
  },
});
