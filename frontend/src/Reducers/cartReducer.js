const initialState = [];

export default function (state = initialState, action) {
    switch (action.type) {
        case 'ADD_TO_CART':
            return [...state, action.payload];
        case 'REMOVE_FROM_CART':
            let array = [...state]
            array.splice(action.payload, 1);
            return array;
        case 'CLEAR_CART':
            return [];
        default:
            return state;
    }
}