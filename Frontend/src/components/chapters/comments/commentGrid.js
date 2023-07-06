import React from "react";
import Comment from "./comment";

export default function CommentGrid({ chapterId, comments, setComments }) {
  const updateCommentHandle = async (index, newComment) => {
    const updatedComments = [...comments];
    updatedComments[index].content = newComment;
    setComments(updatedComments);
  };

  const deleteCommentHandle = async (index) => {
    setComments(comments.filter((_, i) => i !== index));
  };
  return comments.map((comment, index) => (
    <Comment
      key={index}
      chapterId={chapterId}
      comment={comment}
      onUpdateComment={(newComment) => updateCommentHandle(index, newComment)}
      onDeleteComment={() => deleteCommentHandle(index)}
    />
  ));
}
