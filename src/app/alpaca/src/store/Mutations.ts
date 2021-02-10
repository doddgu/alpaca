import RootState from './RootState'
import User from '../model/identity/User'

import Cookies from 'js-cookie'

export default {
    setStaticInfo (state: RootState, staticInfo: any) {
        state.staticInfo = staticInfo
    },
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
    setOverlay (state: RootState, overlay: boolean) {
        state.overlay = overlay
    }
}
