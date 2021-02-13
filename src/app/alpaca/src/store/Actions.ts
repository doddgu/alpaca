import { ActionContext } from 'vuex'
import RootState from './RootState'
import axios from 'axios'
import router from '../router/Index'

const SET_STATIC_INFO = 'setStaticInfo'
const SET_USER = 'setUser'

export default {
    login (context: ActionContext<RootState, RootState>, params: any){
        axios
            .get('api/User', {
                params: params.data
            })
            .then((resp: any) => {
                context.commit(SET_USER, resp.data)
                router.push({ name: 'Index' })
            })
            .catch(() => {
                params.callback()
            })
    }
}
