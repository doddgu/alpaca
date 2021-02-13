import RootState from './RootState'
import User from '../model/identity/User'

import Cookies from 'js-cookie'
import { MenuItem } from '../model/basic/Menu'

export default {
    setUser (state: RootState, user: User) {
        state.user = user
        Cookies.set('user', JSON.stringify(user))
    },
    loadUser (state: RootState) {
        const json = Cookies.get('user')
        if(json) {
            state.user = JSON.parse(json)
        }
    },
    setCurrentMenu (state: RootState, currentMenu: MenuItem) {
        state.currentMenu = currentMenu
    }
}
