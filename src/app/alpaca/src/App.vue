<template>
  <a-config-provider :locale="i18n.global.locale === 'en' ? enUS : zhCN">
    <a-layout style="height: 100vh;">
      <router-view></router-view>
    </a-layout>
  </a-config-provider>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Layout from './Layout.vue'

export default defineComponent({
  name: 'App',
  components: {
    Layout
  }
})
</script>

<script setup lang="ts">
import enUS from 'ant-design-vue/es/locale/en_US'
import zhCN from 'ant-design-vue/es/locale/zh_CN'
import moment from 'moment'
import 'moment/dist/locale/zh-cn'
import i18n from './config/i18n-config'

moment.locale(i18n.global.locale)

</script>

<style>
</style>