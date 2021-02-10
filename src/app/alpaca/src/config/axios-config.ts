import Catcher from '../infrastructure/robust/Catcher'
import router from '../router/Index'
import axios from 'axios'
import store from '../store/Index'

class AxiosConfig {
    isInit = false
    permissionDeniedRecorded = false

    init (): void {
        if (this.isInit) {
            return
        }

        // init axios default config
        axios.defaults.baseURL = 'https://' + window.location.hostname + ':10002'
        axios.defaults.timeout = 60000

        axios.interceptors.request.use(function (config) {
            if (store.state.user !== null) {
                config.headers.common.Authorization = 'Bearer ' + store.state.user.accessToken
            }
            return config
        }, function (error) {
            return Promise.reject(error)
        })
        const _this = this
        axios.interceptors.response.use(function (response) {
            return response
        }, function (error) {
            if (error.response !== undefined && error.response.status === 401) {
                router.push({ name: 'Auth.Login' })
            } else {
                Catcher.showSnackbarByResponse('error', error.response || error)
            }
            return Promise.reject(error)
        })

        this.isInit = true
    }
}

const axiosConfig = new AxiosConfig()

export default axiosConfig
