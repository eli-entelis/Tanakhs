import React, { useState } from "react";
// import { addComment } from "../../../apiRequests/apiRequests";
import { useSelector } from "react-redux";
import { Textarea } from "@mui/joy";
import { Button } from "@mui/material";
import "../../../../node_modules/react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import Auth from "../../auth/auth";

export default function NewCommentSection({
  chapterId,
  comments,
  setComments,
}) {
  const [newComment, setNewComment] = useState("");
  const user = useSelector((state) => state.user.user);

  const addCommentHandle = async (comment) => {
    if (comment.trim() === "") {
      return;
    }
    try {
      // const result = await addComment(chapterId, comment);
      const newCommentObject = {
        content: comment,
        // id: result["_id"],
        name: user.name,
        email: user.email,
      };
      setComments([...comments, newCommentObject]);
    } catch (error) {
      console.log("error", error);
    }
    setNewComment("");
  };

  const handleChange = (event) => {
    setNewComment(event.target.value);
  };

  return (
    <>
      <h4>תגובות נוספות</h4>
      <form
        style={{ display: "flex" }}
        id="comment-form"
        onSubmit={(e) => {
          e.preventDefault();
          addCommentHandle(e.target.elements.comment.value);
          e.target.elements.comment.value = "";
        }}
      >
        <Auth></Auth>
        <Textarea
          style={{ width: "100%" }}
          placeholder="נא להזין את תוכן התגובה"
          name="comment"
          value={newComment}
          onChange={handleChange}
          disabled={!user}
        ></Textarea>
        <br />
        <Button
          disabled={newComment === "" || !user}
          type="submit"
          id="add-comment-btn"
          className="comments-section-button"
          variant="outlined"
          style={{ whiteSpace: "nowrap", marginRight: "0.5rem" }}
        >
          שלח תגובה
        </Button>
      </form>
    </>
  );
}
