import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Button from "react-bootstrap/Button";
import logo from "./Logo.png";
import { Link } from "react-router-dom";

import "../style.css";

function BasicExample() {
  return (
    <Navbar className="px-3 " expand="lg">
      <Navbar.Brand as={Link} to="/ranking">
        <img src={logo} className="logo"></img>
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse
        className="justify-content-lg-end "
        id="basic-navbar-nav"
      >
        <Nav className="align-items-center">
          <Nav.Link className="px-3" as={Link} to="/ranking">
            Ranking
          </Nav.Link>
          <Nav.Link className="px-3" as={Link} to="/kategorie">
            Kategorie
          </Nav.Link>
          <Nav.Link className="px-3" as={Link} to="/kontakt">
            Kontakt
          </Nav.Link>
          <Nav.Link className="px-3" as={Link} to="/profil">
            Profil
          </Nav.Link>
          <Button
            className="px-3 w-25 login-main"
            variant="light"
            as={Link}
            to="/login"
          >
            Zaloguj
          </Button>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default BasicExample;
