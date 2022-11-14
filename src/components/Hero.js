import { Container, Row, Col, Button, Form } from "react-bootstrap";
import Hero123 from "./Hero123.png";

import styles from "./Hero.module.css";
import MeetOurQuizy from "./OurQuizy/MeetOurQuizy";

import Footer from "./Footer/Footer";
import Categories from "./BrowseCategories/Categories";

function HeroPage() {
  return (
    <>
      <Container className={styles.container}>
        <Row>
          <Col>
            <p className={styles.play}>Zagraj w Quiz i zdobywaj punkty!</p>
            <p className={styles.rank_info}>
              Zdobądź pierwsze miejsce w rankingu!
            </p>
            <Row>
              <Col>
                <Form.Control type="email" className={styles.input} />
              </Col>
              <Col>
                <Button variant="light" className={styles.button}>
                  Wyszukaj Quiz
                </Button>
              </Col>
            </Row>

            <p className={styles.something}>
              Liczba graczy w ubiegłym miesiącu
            </p>
            <p className={styles.players}>23,555+</p>
          </Col>
          <Col className={styles.people_col}>
            <div>
              <img src={Hero123} alt="People img" className={styles.img}></img>
            </div>
          </Col>
        </Row>
        <MeetOurQuizy />
        <Categories />
      </Container>
      <Footer />
    </>
  );
}

export default HeroPage;
