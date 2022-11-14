import { Col, Container, Row } from "react-bootstrap";
import { Facebook, Twitter, Instagram } from "react-bootstrap-icons";

import style from "./Footer.module.css";

function Footer() {
  return (
    <Container fluid className={style.footer}>
      <Row>
        <Col>Logo strony</Col>
        <Col>
          <Col className={style.special_text}>Menu</Col>
          <Col>O nas</Col>
          <Col>Blog</Col>
          <Col>Kontakt</Col>
        </Col>
        <Col>
          <Col className={style.special_text}>Platforma</Col>
          <Col>Zarzadzanie</Col>
          <Col>Strategia</Col>
          <Col>Marketing</Col>
        </Col>
        <Col className="d-flex align-items-center">
          <Facebook className={style.icon} />
          <Twitter className={style.icon} />
          <Instagram className={style.icon} />
        </Col>
      </Row>
      <Row className="p-2 mt-3">
        <Col>
          <p>Copyright &copy; 2022 Testify. All Rights Reserved.</p>
        </Col>
        <Col>
          <p>Polityka Prywatności</p>
        </Col>
        <Col>
          <p>Warunki Korzystania</p>
        </Col>
      </Row>
    </Container>
  );
}

export default Footer;
