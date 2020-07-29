const initialState = 0;

export default function (state = initialState, action) {
    switch (action.type) {
        case 'CHANGE_PAGE':
            return action.payload;
        default:
            return state;
    }
}