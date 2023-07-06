import ChapterCard from "./chapterCard";
import React, { useState, useEffect } from "react";
import ReactPlaceholder from "react-placeholder/lib";
import { getChapters } from "../../apiRequests/apiRequests";
import Grid from "@mui/material/Grid";

export const REQUEST_STATUS = {
  LOADING: "loading",
  SUCCESS: "success",
  FAILURE: "failure",
};

function ChapterCardGrid() {
  const [requestStatus, setRequestStatus] = useState(REQUEST_STATUS.LOADING);
  const [chaptersData, setChaptersData] = useState([]);

  let chapters;
  useEffect(() => {
    async function getData() {
      try {
        chapters = await getChapters();
        setChaptersData(chapters);
        setRequestStatus(REQUEST_STATUS.SUCCESS);
      } catch (error) {
        setRequestStatus(REQUEST_STATUS.FAILURE);
      }
    }
    getData();
  }, []);
  return (
    <ReactPlaceholder
      type="media"
      rows={20}
      ready={requestStatus === REQUEST_STATUS.SUCCESS}
    >
      <Grid container spacing={3}>
        {chaptersData.map(function(post) {
          return (
            <Grid item xs={4} key={post.id}>
              <ChapterCard
                _id={post.id}
                title={post.title}
                name={post.name}
                description={post.description}
                chapterChar={post.chapterChar}
                {...(post.chapterRating && {
                  moralRating: String(post.chapterRating.moral),
                  scientificRating: String(post.chapterRating.scientific),
                })}
              />
            </Grid>
          );
        })}
      </Grid>
    </ReactPlaceholder>
  );
}

export default ChapterCardGrid;
