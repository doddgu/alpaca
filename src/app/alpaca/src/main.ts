import { createApp } from 'vue'
import App from './App.vue'
import Antd from 'ant-design-vue'
import 'ant-design-vue/dist/antd.css'
import i18n from './config/i18n-config'
import router from './router/Index'
import store from './store/Index'
import AxiosConfig from './config/axios-config'

AxiosConfig.init()

createApp(App)
    .use(Antd)
    .use(i18n)
    .use(router)
    .use(store)
    .mount('#app')
