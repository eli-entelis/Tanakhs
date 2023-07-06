import "./App.css";
import React from "react";
import { Routes, Route } from "react-router-dom";
import ChapterPost from "./components/chapters/chapter/chapterPost";
import HomePage from "./components/homePage";
import MainNavbar from "./components/mainNavbar";
import Container from "@mui/material/Container";
import { GoogleOAuthProvider } from "@react-oauth/google";

const sections = [
  { title: "הברית הישנה", url: "#" },
  { title: "הברית החדשה", url: "#" },
  { title: "קוראן", url: "#" },
];

function App() {
  return (
    <GoogleOAuthProvider clientId="187351366877-am1eo0p70hrbnm3n9jfeumaif87a6io5.apps.googleusercontent.com">
      <div>
        <Container maxWidth="lg" className=".main-div">
          <MainNavbar title='תנ"כס' sections={sections} />

          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/chapter/:_id" element={<ChapterPost />} />
          </Routes>
        </Container>
      </div>
    </GoogleOAuthProvider>
  );
}

export default App;
