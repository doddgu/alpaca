import Catcher from '../infrastructure/robust/Catcher'
import router from '../router/Index'
import axios from 'axios'
import store from '../store/Index'
import I18nHelper from '../infrastructure/robust/helpers/I18nHelper'

class AxiosConfig {
    isInit = false
    permissionDeniedRecorded = false

    init(): void {
        if (this.isInit) {
            return
        }

        // init axios default config
        axios.defaults.baseURL = 'http://' + window.location.hostname + ':10002'
        axios.defaults.timeout = 60000

        axios.interceptors.request.use(
            function (config) {
                if (store.state.user !== null) {
                    config.headers.common.Authorization = 'Bearer ' + store.state.user.accessToken
                }
                return config
            },
            function (error) {
                return Promise.reject(error)
            }
        )

        axios.interceptors.response.use(
            function (response) {
                return response
            },
            function (error) {
                if (error.response === undefined) {
                    Catcher.showErrorMessage(error.message)
                } else if (error.response.status === 401) {
                    router.push({ name: 'Auth.Login' })
                } else if (error.response.status === 403) {
                    Catcher.showErrorMessage(I18nHelper.t('text.forbidden'))
                } else {
                    Catcher.showMessageByErrorCode(error.response)
                }
                return Promise.reject(error)
            }
        )

        this.isInit = true
    }
}

const axiosConfig = new AxiosConfig()

export default axiosConfig
