<template>
    <a-layout-header class="header">
        <div class="logo">
            <img src="./assets/logo.png" alt="logo" />
        </div>
        <a-menu
            theme="dark"
            mode="horizontal"
            v-model:selectedKeys="currentTopMenu"
            :style="{ lineHeight: '64px', 'float': 'right' }"
        >
            <a-sub-menu>
                <template #title>
                    <span class="submenu-title-wrapper">
                        <setting-outlined />
                        <UserOutlined />
                        {{ store.state.user.nickName }}
                    </span>
                </template>
                <a-menu-item-group :title="$t('text.account')">
                    <a-menu-item key="logout" @click="logout">{{ $t('text.logout') }}</a-menu-item>
                </a-menu-item-group>
            </a-sub-menu>
        </a-menu>
        <a-menu
            theme="dark"
            mode="horizontal"
            v-model:selectedKeys="currentTopMenu"
            :style="{ lineHeight: '64px', 'float': 'right' }"
        >
            <a-sub-menu>
                <template #title>
                    <span class="submenu-title-wrapper">
                        <setting-outlined />
                        {{ $t('text.currentLang') }}
                    </span>
                </template>
                <a-menu-item-group :title="$t('text.lang')">
                    <a-menu-item key="setting:en" @click="setLocale('en')">English</a-menu-item>
                    <a-menu-item key="setting:zh" @click="setLocale('zh')">中文</a-menu-item>
                </a-menu-item-group>
            </a-sub-menu>
        </a-menu>
    </a-layout-header>
    <a-layout>
        <a-layout-sider width="200" style="background: #fff">
            <a-menu
                mode="inline"
                v-model:selectedKeys="selectedKeys2"
                v-model:openKeys="openKeys"
                :style="{ height: '100%', borderRight: 0 }"
            >
                <a-sub-menu key="sub1">
                    <template #title>
                        <span>
                            <user-outlined />subnav 1
                        </span>
                    </template>
                    <a-menu-item key="1">option1</a-menu-item>
                    <a-menu-item key="2">option2</a-menu-item>
                    <a-menu-item key="3">option3</a-menu-item>
                    <a-menu-item key="4">option4</a-menu-item>
                </a-sub-menu>
                <a-sub-menu key="sub2">
                    <template #title>
                        <span>
                            <laptop-outlined />subnav 2
                        </span>
                    </template>
                    <a-menu-item key="5">option5</a-menu-item>
                    <a-menu-item key="6">option6</a-menu-item>
                    <a-menu-item key="7">option7</a-menu-item>
                    <a-menu-item key="8">option8</a-menu-item>
                </a-sub-menu>
                <a-sub-menu key="sub3">
                    <template #title>
                        <span>
                            <notification-outlined />subnav 3
                        </span>
                    </template>
                    <a-menu-item key="9">option9</a-menu-item>
                    <a-menu-item key="10">option10</a-menu-item>
                    <a-menu-item key="11">option11</a-menu-item>
                    <a-menu-item key="12">option12</a-menu-item>
                </a-sub-menu>
            </a-menu>
        </a-layout-sider>
        <a-layout style="padding: 0 24px 24px">
            <a-breadcrumb style="margin: 16px 0">
                <a-breadcrumb-item>Home</a-breadcrumb-item>
                <a-breadcrumb-item>List</a-breadcrumb-item>
                <a-breadcrumb-item>App</a-breadcrumb-item>
            </a-breadcrumb>
            <a-layout-content
                :style="{ background: '#fff', padding: '24px', margin: 0, minHeight: '100%' }"
            >
                <a-button>{{ $t("text.save") }}</a-button>
                <a-pagination :total="50" show-size-changer />
            </a-layout-content>
        </a-layout>
    </a-layout>
    <a-layout-footer style="text-align: center">
        Alpaca ©2021 Created by
        <a
            href="https://github.com/doddgu/alpaca"
            target="_blank"
        >doddgu@github</a>
    </a-layout-footer>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import HelloWorld from './components/HelloWorld.vue'

export default defineComponent({
    name: 'Layout',
    components: {
        HelloWorld
    }
})
</script>

<script setup lang="ts">
import { computed } from 'vue'
import i18n from './config/i18n-config'
import { useStore } from 'vuex'
import User from './model/identity/User'
import { UserOutlined } from '@ant-design/icons-vue'
import moment from 'moment'
import Cookies from 'js-cookie'

const store = useStore()

ref: currentTopMenu = ['']
ref: selectedKeys2 = ['1']
ref: collapsed = false
ref: openKeys = ['sub1']

function logout() {
    store.commit('setUser', new User())
    window.location.reload()
}

function setLocale(locale: string) {
    i18n.global.locale = locale
    moment.locale(i18n.global.locale)
    i18n.global.locale = i18n.global.locale
    Cookies.set('locale', i18n.global.locale)
}
</script>

<style>
.logo {
    float: left;
    width: 160px;
    height: 60px;
}
</style>