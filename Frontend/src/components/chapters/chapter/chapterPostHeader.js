import React from "react";

export default function ChapterPostHeader(props) {
  return (
    <div>
      <h1>{props.book}</h1>
      <h2>פרק {props.chapter_letters}</h2>
    </div>
  );
}
