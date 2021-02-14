import { message } from 'ant-design-vue'
import i18n from '../../config/i18n-config'

export default class Catcher {
    static alert(e: any) {
        if (e.response !== undefined && e.response.status === 401) {
            return
        }

        alert(Catcher.message(e))
    }

    static message(e: any) {
        const data = e.data || {}
        const resp = e.response || {
            data: data.ExceptionMessage || data.Message || e.message || data
        }
        return resp.data
    }

    static showErrorMessage(msg: string) {
        message.error(msg)
    }

    static showMessageByErrorCode(resp: any) {
        const msg = resp.data[i18n.global.locale.toUpperCase() + 'Message']
        message.error(msg)
    }
}
