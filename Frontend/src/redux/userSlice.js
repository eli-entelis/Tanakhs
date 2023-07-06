import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  user: JSON.parse(sessionStorage.getItem("user")) || null,
  loggedIn: false,
};

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {
    login: (state, action) => {
      const user = action.payload;
      sessionStorage.setItem("user", JSON.stringify(user));
      return { user, loggedIn: true };
    },
    logout: (state, action) => {
      sessionStorage.removeItem("user");
      return { user: null, loggedIn: false };
    },
  },
});

export const { login, logout } = userSlice.actions;
export default userSlice.reducer;
