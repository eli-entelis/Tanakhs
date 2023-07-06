import React, { useState, useEffect } from "react";

import { useParams } from "react-router-dom";
import ReactPlaceholder from "react-placeholder/lib";
import ChapterPostHeader from "./chapterPostHeader";
// import ChapterPostVerses from "./chapterPostVerses";
import NewCommentSection from "../comments/newCommentSection";
import { getChapter } from "../../../apiRequests/apiRequests";
import CommentGrid from "../comments/commentGrid";
export const REQUEST_STATUS = {
  LOADING: "loading",
  SUCCESS: "success",
  FAILURE: "failure",
};
function ChapterPost() {
  let { _id } = useParams();
  const [requestStatus, setRequestStatus] = useState(REQUEST_STATUS.LOADING);
  const [chapterData, setChapterData] = useState([]);
  const [comments, setComments] = useState([]);
  useEffect(() => {
    async function getChapterData() {
      try {
        var chapter = await getChapter(String(_id));
        setChapterData(chapter);
        setComments(chapter.comments);
        setRequestStatus(REQUEST_STATUS.SUCCESS);
      } catch (error) {
        setRequestStatus(REQUEST_STATUS.FAILURE);
      }
    }
    getChapterData();
  }, []);
  return (
    <ReactPlaceholder
      type="media"
      rows={20}
      ready={requestStatus === REQUEST_STATUS.SUCCESS}
    >
      <ChapterPostHeader
        book={chapterData.book}
        chapter_letters={chapterData.chapterChar}
      ></ChapterPostHeader>
      {/* <ChapterPostVerses verses={chapterData.verses}></ChapterPostVerses> */}
      <p>{chapterData.content}</p>
      <NewCommentSection
        chapterId={chapterData["id"]}
        comments={comments}
        setComments={setComments}
      ></NewCommentSection>
      <CommentGrid
        chapterId={chapterData["id"]}
        comments={comments}
        setComments={setComments}
      ></CommentGrid>
    </ReactPlaceholder>
  );
}
export default ChapterPost;
