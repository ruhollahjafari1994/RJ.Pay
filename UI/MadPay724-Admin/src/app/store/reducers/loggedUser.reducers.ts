import * as loggedUserAction from '../actions';
import { User } from 'src/app/data/models/user';

export type LoggedUserActions = loggedUserAction.AllLoggedUserAction;

export const initLoggedUserState: User = {
    id: '',
    name: '',
    userName: '',
    phoneNumber: '',
    address: '',
    gender: false,
    age: 0,
    lastActive: null,
    city: '',
    photoUrl: './assets/img/profilepic.png',
    provider : 'MADPAY'
}
export function loggedUserReducer(state = initLoggedUserState, action: LoggedUserActions) {
    switch (action.type) {
        case loggedUserAction.LoggedUserActionTypes.LOADLOGGEDUSER:
            return state;
        case loggedUserAction.LoggedUserActionTypes.LOADLOGGEDUSER_SUCCESS:
            return {
                ...state, id: action.payload.id,
                name: action.payload.name,
                userName: action.payload.userName,
                phoneNumber: action.payload.phoneNumber,
                address: action.payload.address,
                gender: action.payload.gender,
                age: action.payload.age,
                lastActive: action.payload.lastActive,
                city: action.payload.city,
                photoUrl: action.payload.photoUrl,
                provider: action.payload.provider,
            }
        case loggedUserAction.LoggedUserActionTypes.LOADLOGGEDUSER_FAIL: {
            return state;
        }
            
        case loggedUserAction.LoggedUserActionTypes.EDIT_LOGGEDUSER:
            return {
                ...state, id: action.payload.id,
                name: action.payload.name,
                userName: action.payload.userName,
                phoneNumber: action.payload.phoneNumber,
                address: action.payload.address,
                gender: action.payload.gender,
                age: action.payload.age,
                lastActive: action.payload.lastActive,
                city: action.payload.city,
                photoUrl: action.payload.photoUrl,
                provider: action.payload.provider,
            }
        //return Object.assign({}, state, action.payload);
        case loggedUserAction.LoggedUserActionTypes.EDIT_LOGGEDUSERNAME:
            return { ...state, name: action.payload }
        case loggedUserAction.LoggedUserActionTypes.EDIT_LOGGEDUSERPHOTOURL:
            return { ...state, photoUrl: action.payload }
        case loggedUserAction.LoggedUserActionTypes.RESET_LOGGEDUSER:
            return initLoggedUserState;
        case loggedUserAction.LoggedUserActionTypes.UPDATEINFO_LOGGEDUSER:
            return {
                ...state,
                name: action.payload.name,
                phoneNumber: action.payload.phoneNumber,
                address: action.payload.address,
                gender: action.payload.gender,
                city: action.payload.city
            }
        default:
            return state;
    }
}