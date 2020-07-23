import { combineReducers } from 'redux';
import page from './pageReducer';
import search from './searchReducer';
import cart from './cartReducer';

export default combineReducers({
    page,
    search,
    cart
});