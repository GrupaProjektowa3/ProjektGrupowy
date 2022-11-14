import styles from "./MeetOurQuizy.module.css";
import { Col, Row, Button } from "react-bootstrap";
import QuizCard from "../QuizCard/QuizCard";
import { Link } from "react-router-dom";

function MeetOurQuizy(props) {
  const testoweDane = [
    {
      id: "q1",
      title: "Jakim nalesnikiem jestes",
      image:
        "https://www.blwpapu.pl/img/blog/nalesniki-pszenne-blw-przepisy_45_original.jpg",
    },
    // {
    //   id: "q2",
    //   title: "Czy piwo to twoje paliwo",
    //   image:
    //     "https://www.kwestiasmaku.com/sites/v123.kwestiasmaku.com/files/nalesniki_01_1.jpg",
    // },
    // {
    //   id: "q3",
    //   title: "Jakim nalesnikiem jestes",
    //   image:
    //     "https://www.kwestiasmaku.com/sites/v123.kwestiasmaku.com/files/nalesniki_01_1.jpg",
    // },
    // {
    //   id: "q4",
    //   title: "Czy jestes fanem disco",
    //   image:
    //     "https://www.kwestiasmaku.com/sites/v123.kwestiasmaku.com/files/nalesniki_01_1.jpg",
    // },
    // {
    //   id: "q5",
    //   title: "Wiedzmin quiz",
    //   image:
    //     "https://www.kwestiasmaku.com/sites/v123.kwestiasmaku.com/files/nalesniki_01_1.jpg",
    // },
    // {
    //   id: "q6",
    //   title: "Czy jestes polakiem",
    //   image:
    //     "https://www.kwestiasmaku.com/sites/v123.kwestiasmaku.com/files/nalesniki_01_1.jpg",
    // },
  ];
  console.log(testoweDane[0]);
  return (
    <>
      <Row>
        <Col>
          <p className={styles.meet_text}>Poznaj nasze quizy</p>
        </Col>
        <Col className="d-flex flex-row-reverse align-items-center">
          <Button className={styles.browse_button} variant="outline-dark">
            Przeglądaj
          </Button>
        </Col>
      </Row>
      <Row className="py-4 mx-auto">
        <Col xs={5}>
          <Link to="/login">
            <QuizCard title={testoweDane[0].title} img={testoweDane[0].image} />
          </Link>
        </Col>
        <Col>
          <QuizCard />
        </Col>
        <Col>
          <QuizCard last />
        </Col>
      </Row>
      <Row className="mx-auto">
        <Col>
          <QuizCard />
        </Col>
        <Col>
          <QuizCard />
        </Col>
        <Col>
          <QuizCard />
        </Col>
      </Row>
    </>
  );
}

export default MeetOurQuizy;
