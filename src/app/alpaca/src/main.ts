import { createApp } from 'vue'
import App from './App.vue'
import Antd from 'ant-design-vue'
import 'ant-design-vue/dist/antd.css'
import i18n from './config/i18n-config'
import router from './router/Index'
import store from './store/Index'
import * as antIcons from '@ant-design/icons-vue'
import AxiosConfig from './config/axios-config'

const app = createApp(App)

const ai: any = antIcons

Object.keys(antIcons).forEach(key => {
    app.component(key, ai[key])
})
  
store.state.antIcons = antIcons

AxiosConfig.init()

app.use(Antd)
    .use(i18n)
    .use(router)
    .use(store)
    .mount('#app')
