import { createStore, createLogger } from 'vuex'
import RootState from './RootState'
import Mutations from './Mutations'
import Actions from './Actions'

declare var process : {
    env: {
        NODE_ENV: string
    }
}

export default createStore({
    state: new RootState(),
    mutations: Mutations,
    actions: Actions,
    modules: {
    },
    plugins: process.env.NODE_ENV !== 'production'
    ? [createLogger()]
    : []
})
