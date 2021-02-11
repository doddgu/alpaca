import store from '../../store/Index'
import { message } from 'ant-design-vue'
import i18n from '../../config/i18n-config'

export default class Catcher {
    static alert (e: any) {
        if (e.response !== undefined && e.response.status === 401) {
            return
        }

        alert(Catcher.message(e))
    }

    static message (e: any) {
        const data = e.data || {}
        const resp = e.response || { data: (data.ExceptionMessage || data.Message || e.message || data) }
        return resp.data
    }

    static showSnackbarByResponse (color: string, e: any) {
        if (e.response !== undefined && e.response.status === 401) {
            return
        }

        store.state.snackbar.isShow = true
        store.state.snackbar.color = color
        store.state.snackbar.text = Catcher.message(e)
    }

    static showSnackbar (color: string, text: string) {
        store.state.snackbar.isShow = true
        store.state.snackbar.color = color
        store.state.snackbar.text = text
    }

    static showMessageByResponse (resp: any) {
        const msg = resp.data[i18n.global.locale.toUpperCase() + "Message"]
        message.error(msg)
    }
}
