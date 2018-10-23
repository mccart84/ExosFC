const requestMembersType = 'REQUEST_MEMBERS';
const receiveMembersType = 'RECEIVE_MEMBERS';
const initialState = { memberData: [], isLoading: false };

export const actionCreators = {
    requestMembers: memberData => async (dispatch, getState) => {
        dispatch({ type: requestMembersType });

        const url = 'https://xivapi.com/freecompany/9233786610993142599?data=FCM'
        const response = await fetch(url);
        const members = await response.json();

        dispatch({ type: receiveMembersType, members });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestMembersType) {
        return {
            ...state,
            memberData: null,
            isLoading: true
        };
    }

    if (action.type === receiveMembersType) {
        return {
            ...state,
            memberData: action.memberData,
            members: action.members,
            isLoading: false
        };
    }

    return state;
};
