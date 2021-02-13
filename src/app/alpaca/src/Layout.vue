<template>
    <a-layout-header class="header">
        <div class="logo" @click="router.push({ name: 'Index' })">
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
                v-model:selectedKeys="selectedMenu"
                v-model:openKeys="openKeys"
                :style="{ height: '100%', borderRight: 0 }"
            >
                <template v-for="(menu, mi) in store.state.menu.items" :key="'menu_' + mi">
                    <a-sub-menu v-if="menu.sub && menu.sub.length > 0" :key="'menu_' + mi">
                        <template #title>
                            <span>
                                <component :is="store.state.antIcons[menu.icon]" v-if="menu.icon" />
                                {{ $t(menu.title) }}
                            </span>
                        </template>
                        <a-menu-item
                            v-for="(subMenu, smi) in menu.sub"
                            :key="'menu_' + mi + '_' + smi"
                            @click="route(subMenu.link)"
                        >
                            <span>
                                <component :is="subMenu.icon" v-if="subMenu.icon" />
                                {{ $t(subMenu.title) }}
                            </span>
                        </a-menu-item>
                    </a-sub-menu>
                    <a-menu-item v-else :key="'menu_' + mi" @click="route(menu.link)">
                        <span>
                            <component :is="menu.icon" v-if="menu.icon" />
                            {{ $t(menu.title) }}
                        </span>
                    </a-menu-item>
                </template>
            </a-menu>
        </a-layout-sider>
        <a-layout style="padding: 24px 24px 0px 24px">
            <Index v-if="router.currentRoute.value.name === 'Index'" />
            <router-view v-else></router-view>
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
import { defineComponent, watch } from 'vue'
import Index from './views/Index.vue'

export default defineComponent({
    name: 'Layout',
    components: {
        Index
    }
})
</script>

<script setup lang="ts">
import { computed } from 'vue'
import i18n from './config/i18n-config'
import RootState from './store/RootState'
import { useStore } from 'vuex'
import User from './model/identity/User'
import { UserOutlined } from '@ant-design/icons-vue'
import moment from 'moment'
import Cookies from 'js-cookie'
import router from './router/Index'
import { MenuItem } from './model/basic/Menu'

const store = useStore<RootState>()

ref: currentTopMenu = ['']
ref: selectedMenu = ['']
ref: openKeys = ['']

function logout() {
    store.commit('setUser', new User())
    window.location.reload()
}

function setLocale(locale: string) {
    i18n.global.locale = locale
    moment.locale(i18n.global.locale)
    i18n.global.locale = i18n.global.locale
    Cookies.set('locale', i18n.global.locale)

    window.location.reload()
}

function route(name: string) {
    if (name) {
        router.push({ name: name })
    }
}

function getCurrentMenu(link: any): MenuItem {
    let currentMenu = new MenuItem()
    if (!link || link.length === 0) return currentMenu

    let key = ''

    for (let mi = 0; mi < store.state.menu.items.length; mi++) {
        const menu = store.state.menu.items[mi];

        if (menu.link === link) {
            key = mi.toString()
            currentMenu = menu
            break
        } else if (menu.sub && menu.sub.length > 0) {
            for (let smi = 0; smi < menu.sub.length; smi++) {
                const subMenu = menu.sub[smi];

                if (subMenu.link === link) {
                    key = mi + '_' + smi
                    currentMenu = subMenu
                    break
                }
            }
        }
    }

    selectedMenu[0] = 'menu_' + key

    return currentMenu
}

const currentLeftMenu = computed(() => {
    const currentMenu = getCurrentMenu(router.currentRoute.value.name)
    store.commit('setCurrentMenu', currentMenu)

    return currentMenu
})

watch(currentLeftMenu, () => {
    // nothing to do, effect computed
})
</script>

<style>
.logo {
    float: left;
    width: 160px;
    height: 60px;
    cursor: pointer;
}
.layout-content {
    background: #fff;
    padding: 24px;
    margin: 24px 0px 0px 0px;
    min-height: 100%;
}
</style>