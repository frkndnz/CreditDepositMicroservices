import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Nav, Navbar as BootstrapNavbar } from 'react-bootstrap';

function Navbar() {
  return (
    <BootstrapNavbar bg="dark" variant="dark" expand="lg">
      <Container>
        {/* Logo */}
        <BootstrapNavbar.Brand as={Link} to="/">
          Logo
        </BootstrapNavbar.Brand>
        
        <BootstrapNavbar.Toggle aria-controls="basic-navbar-nav" />
        <BootstrapNavbar.Collapse id="basic-navbar-nav">
          {/* Sol taraftaki linkler */}
          <Nav className="me-auto">
            <Nav.Link as={Link} to="/">
              Home
            </Nav.Link>
            <Nav.Link as={Link} to="/customers">
              Customers
            </Nav.Link>
          </Nav>

          {/* Sağ taraftaki link */}
          <Nav>
            <Nav.Link as={Link} to="/about">
              About
            </Nav.Link>
          </Nav>
        </BootstrapNavbar.Collapse>
      </Container>
    </BootstrapNavbar>
  );
}

export default Navbar;