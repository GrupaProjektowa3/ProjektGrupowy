import { Card } from "react-bootstrap";
import styles from "./QuizCard.module.css";

function QuizCard(props) {
  return (
    <Card
      className={`${styles.quizcard} ${props.last ? styles.lastcard : null}`}
    >
      <Card.Img variant="top" src={props.img} className={styles.img} />
      <Card.Body>
        <Card.Title className={styles.card_title}>{props.title}</Card.Title>
      </Card.Body>
    </Card>
  );
}

export default QuizCard;
