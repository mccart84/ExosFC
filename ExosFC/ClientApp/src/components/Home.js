import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
    <div>
        <div style={{ margin: 'auto', width: '100%', textAlign: 'center', color: 'white' }}>
            <h1>Welcome to Exodus Knights Free Company on Coeurl</h1>
            <h4>Looking for a fresh start or a new beginning? Come join Exodus Knights! We are a chill, casual-midcore free company with active raiders, crafters and helpful members!</h4>
            <h4>We hold events regularly!</h4>
        </div>
        <div class="row" style={{ marginTop: '10%' }}>
            <div class="column">
            </div>
            <div class="column">
                <div style={{ margin: 'auto', width: '100%', textAlign: 'center' }}>
                    <iframe src="https://discordapp.com/widget?id=503283816807530496&theme=dark" width="350" height="500" allowtransparency="true" frameborder="0"></iframe>
                </div>
            </div>
        </div>

    </div>
);

export default connect()(Home);
