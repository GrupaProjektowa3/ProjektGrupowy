import { Card } from "react-bootstrap";
import styles from "./CategorieCard.module.css";
import testimg from "./Bitmap.png";

function CategorieCard(props) {
  return (
    <Card
      className={`${styles.card_categorie} ${
        props.primary ? styles.bg_FFF2E6 : null
      }`}
    >
      <Card.Img variant="top" src={testimg} className={styles.img} />
      <Card.Body>
        <Card.Title className={styles.card_title}>Matematyka </Card.Title>
        <Card.Text>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent
          vulputate scelerisque ex, vitae porta augue molestie ac.
        </Card.Text>
      </Card.Body>
    </Card>
  );
}

export default CategorieCard;
