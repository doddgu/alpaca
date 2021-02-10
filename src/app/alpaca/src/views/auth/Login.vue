<template>
    <a-layout>
        <a-layout style="padding: 0 24px 24px; background: #001529;">
            <a-layout-content :style="{ margin: 0, minHeight: '100%' }">
                <a-row
                    type="flex"
                    justify="center"
                    align="middle"
                    :style="{ margin: 0, minHeight: '100%' }"
                >
                    <a-col>
                        <a-row justify="center">
                            <a-col>
                                <img src="../../assets/logo.png" alt="logo" />
                            </a-col>
                        </a-row>
                        <a-row>
                            <a-col>
                                <a-card style="width: 400px; padding-top: 12px;">
                                    <a-row>
                                        <a-col>
                                            <a-input
                                                placeholder="User Name"
                                                v-model:value="userName"
                                            >
                                                <template #suffix>
                                                    <user-outlined type="user" />
                                                </template>
                                            </a-input>
                                            <a-input-password
                                                v-model:value="password"
                                                placeholder="Password"
                                                style="margin-top: 24px;"
                                                @pressEnter="login"
                                            />
                                        </a-col>
                                    </a-row>
                                    <a-row justify="center" style="margin-top: 24px;">
                                        <a-col>
                                            <a-button
                                                type="primary"
                                                :loading="loading"
                                                style="width: 120px;"
                                                @click="login"
                                            >Login</a-button>
                                        </a-col>
                                    </a-row>
                                </a-card>
                            </a-col>
                        </a-row>
                    </a-col>
                </a-row>
            </a-layout-content>
        </a-layout>
    </a-layout>
    <a-layout-footer style="text-align: center; background: #001529; color: white;">
        Alpaca ©2021 Created by
        <a
            href="https://github.com/doddgu/alpaca"
            target="_blank"
        >doddgu@github</a>
    </a-layout-footer>
</template>

<script lang="ts">
import { ref, defineComponent } from 'vue'
export default defineComponent({
    name: 'Login',
    props: {
        msg: {
            type: String,
            required: true
        }
    },
    setup: () => {
        const count = ref(0)
        const useScriptSetup = ref(false)
        const useTsPlugin = ref(false)
        return { count, useScriptSetup, useTsPlugin }
    }
})
</script>

<script setup lang="ts">
import { UserOutlined } from '@ant-design/icons-vue'
import { useStore } from 'vuex'
ref: userName = ''
ref: password = ''
ref: loading = false
const store = useStore()

function login() {
    if (loading) return
    loading = true
    store.dispatch('login', {
        data: {
            userName: userName,
            password: password
        },
        callback: () => {
            loading = false
        }
    })
}
</script>

<style scoped>
</style>
