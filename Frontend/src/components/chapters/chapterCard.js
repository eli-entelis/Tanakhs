import React from "react";
import ChapterRatings from "./chapterRatings";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import { useNavigate } from "react-router-dom";

export default function ChapterCard({
  _id,
  title,
  name,
  description,
  chapterChar,
  moralRating,
  scientificRating,
}) {
  const navigate = useNavigate();

  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardMedia
        sx={{ height: 140 }}
        image="https://meyda.education.gov.il/files/pop/2418/%D7%91%D7%A8%D7%99%D7%90%D7%AA%D7%A2%D7%95%D7%9C%D7%9D%D7%97%D7%98%D7%A2.jpg"
        title="green iguana"
      />
      <CardContent>
        <Typography variant="h5" component="div">
          {title}
        </Typography>
        <Typography
          variant="h6"
          color="text.secondary"
          className="post-text"
          gutterBottom
        >
          {name}: {chapterChar}'
        </Typography>
        <Typography gutterBottom variant="body2" color="text.secondary">
          {description}
        </Typography>
        <ChapterRatings value={moralRating} title="מוסר" />
        <ChapterRatings value={scientificRating} title="מדע" />
      </CardContent>
      <CardActions>
        <Typography>
          <Button size="small">שתפו</Button>
          <Button
            size="small"
            onClick={() => navigate(`/chapter/${String(_id)}`)}
          >
            קראו עוד
          </Button>
        </Typography>
      </CardActions>
    </Card>
  );
}
