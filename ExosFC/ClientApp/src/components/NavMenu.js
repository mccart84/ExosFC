import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
    <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
            <Navbar.Brand>
                <Link to={'/'}>Exodus Knights</Link>
            </Navbar.Brand>
        <Navbar.Toggle />
    </Navbar.Header>
    <Navbar.Collapse>
        <Nav>
            <LinkContainer to={'/'} exact>
                <NavItem>
                    <Glyphicon glyph='home' /> Home
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/counter'}>
                <NavItem>
                    <Glyphicon glyph='education' /> Counter
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/fetchdata'}>
                <NavItem>
                    <Glyphicon glyph='th-list' /> Fetch data
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/members'}>
                <NavItem>
                    <Glyphicon glyph='user' /> Members
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/raidTeams'}>
                <NavItem>
                    <Glyphicon glyph='king' /> Raid Teams
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/events'}>
                <NavItem>
                    <Glyphicon glyph='bookmark' /> Events
                </NavItem>
            </LinkContainer>
            <LinkContainer to={'/jobRequests'}>
                <NavItem>
                   <Glyphicon glyph='grain' /> Job Requests
                </NavItem>
            </LinkContainer>
        </Nav>
    </Navbar.Collapse>
  </Navbar>
);
