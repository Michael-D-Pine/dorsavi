import { Container, Navbar, Nav, NavDropdown, Form, FormControl, Button } from 'react-bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css';
import Logo from './logo.svg'
import {
    Link
  } from "react-router-dom";
const Header = (props) => {
    return (
    <Container>
      <Navbar bg="light">
        <Navbar.Brand href="#home">
          <img
            src={Logo}
            width="120"
            height="20"
            className="d-inline-block align-top"
            alt="React Bootstrap logo"
          />
        </Navbar.Brand>
        <h4>- dorsaVi code challenge</h4>
        <Nav className="mr-auto">
          <Nav.Link><Link to="/cats">Cats</Link></Nav.Link>
          <Nav.Link><Link to="/add">Addition</Link></Nav.Link>
        </Nav>
      </Navbar>
      {props.children}
    </Container>
    )
}

export default Header