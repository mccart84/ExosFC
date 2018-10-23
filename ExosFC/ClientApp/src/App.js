import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Members from './components/Members';
import RaidTeams from './components/RaidTeams';
import JobRequests from './components/JobRequests';
import Events from './components/Events';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/members' component={Members} />
        <Route path='/raidteams' component={RaidTeams} />
        <Route path='/jobrequests' component={JobRequests} />
        <Route path='/events' component={Events} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
    </Layout>
);
