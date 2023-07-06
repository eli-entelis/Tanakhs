import React from "react";
import useCollapse from "react-collapsed";

function Collapsible(props) {
  const { getCollapseProps, getToggleProps } = useCollapse();
  return (
    <div className="collapsible">
      <div className="header" {...getToggleProps()}>
        כל הפרק
      </div>
      <div {...getCollapseProps()}>
        <div>
          {props.verses.map(function (verse, index) {
            return <p key={index}>{verse}</p>;
          })}
        </div>
      </div>
    </div>
  );
}
export default function ChapterPostVerses(props) {
  return (
    <div>
      <Collapsible verses={props.verses}></Collapsible>
    </div>
  );
}
