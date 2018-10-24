import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/members';

const API = 'https://xivapi.com/freecompany/9233786610993142599?data=FCM'

class Members extends Component {
    constructor(props) {
        super(props);

        this.state = {
            memberData: null,
            isLoading: false,
        };
    }

    componentDidMount() {
        this.setState({ isLoading: true })

        fetch(API)
            .then(response => response.json())
            .then(data => this.setState({ memberData: data, isLoading: false }))
    }

    render() {
        const { memberData, isLoading } = this.state;

        if (isLoading)
            return <p>Loading ...</p>;

        return (
            <div>
                {buildMemberRows(memberData)}
            </div>
        );
    }
}

function redirectToLodestone(id) {
        if (typeof window !== 'undefined') {
            window.location.href = "https://na.finalfantasyxiv.com/lodestone/character/" + id + "/";
        }
}

function buildMemberRows(props) {
    if (props != null && props.FreeCompanyMembers != null) {
        return (
            <table className='table table-collapse'>
                <tbody>
                    {props.FreeCompanyMembers.map(member =>
                        <tr key={member.ID}>
                            <td><a href={'https://na.finalfantasyxiv.com/lodestone/character/' + member.ID + '/'}><img src={member.Avatar} height="35px" width="35px"/></a></td>
                            <td style={{ paddingTop: 15 + 'px', fontSize: 18 + 'px', color: '#dc9910'}}>{member.Name}</td>
                            <td style={{ paddingTop: 15 + 'px', fontSize: 18 + 'px', color: '#dc9910' }}><img src={member.RankIcon} height="20px" /> {member.Rank}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}

export default Members;
