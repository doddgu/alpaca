import { createStore } from 'vuex'
import RootState from './RootState'
import Mutations from './Mutations'
import Actions from './Actions'

export default createStore({
    state: new RootState(),
    mutations: Mutations,
    actions: Actions,
    modules: {
    }
})
