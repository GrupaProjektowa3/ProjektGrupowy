import CategorieCard from "../CategoriesCards/CategorieCard";

import styles from "./Categories.module.css";
import { Col, Row, Dropdown } from "react-bootstrap";

function Categories() {
  return (
    <>
      <Row>
        <Col>
          <p className={styles.cat_text}>Poznaj nasze kategorie</p>
        </Col>
        <Col className="d-flex flex-row-reverse align-items-center">
          <Dropdown>
            <Dropdown.Toggle
              variant="success"
              id="dropdown-basic"
              className={styles.dropdown}
            >
              Wybierz kategorie
            </Dropdown.Toggle>
            <Dropdown.Menu>
              <Dropdown.Item href="#/action-1">Sport</Dropdown.Item>
              <Dropdown.Item href="#/action-2">Nauka</Dropdown.Item>
              <Dropdown.Item href="#/action-3">Smieszne</Dropdown.Item>
            </Dropdown.Menu>
          </Dropdown>
        </Col>
      </Row>
      <Row className="py-4 mx-auto last_row">
        <Col xs={5}>
          <CategorieCard primary />
        </Col>
        <Col>
          <CategorieCard primary />
        </Col>
        <Col>
          <CategorieCard />
        </Col>
      </Row>
      <Row className="py-4 mx-auto">
        <Col>
          <CategorieCard />
        </Col>
        <Col>
          <CategorieCard />
        </Col>
        <Col xs={5}>
          <CategorieCard primary />
        </Col>
      </Row>
    </>
  );
}
export default Categories;
