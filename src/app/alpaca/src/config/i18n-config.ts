
import { createI18n } from 'vue-i18n'
import en from '../assets/lang/en-US'
import zh from '../assets/lang/zh-CN'
import Cookies from 'js-cookie'

const locale = Cookies.get('locale') || 'en'

const i18n = createI18n({
    locale: locale,
    fallbackLocale: 'en',
    messages: {
        en,
        zh
    }
})

export default i18n
