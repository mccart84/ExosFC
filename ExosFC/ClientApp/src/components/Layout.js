import React from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import NavMenu from './NavMenu';

export default props => (
  <Grid fluid>
    <Row>
      <Col sm={2}>
        <NavMenu />
      </Col>
            <Col sm={10} style={{paddingTop: 50 + 'px'}}>
        {props.children}
      </Col>
    </Row>
  </Grid>
);
