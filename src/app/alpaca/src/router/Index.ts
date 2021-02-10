import { createRouter, createWebHashHistory } from 'vue-router'
import store from '../store/Index'

const routes = [
        {
            path: '/Auth/Login',
            name: 'Auth.Login',
            component: () => import('../views/auth/Login.vue'),
            meta: {
                requireAuth: false
            }
        },
        {
            path: '/',
            name: 'Index',
            component: () => import('../Layout.vue'),
            meta: {
                requireAuth: true
            },
            children: [
                // A
                {
                    path: 'A/B',
                    name: 'A.B',
                    component: () => import('../components/HelloWorld.vue'),
                    meta: {
                        menu: 'A.B',
                        requireAuth: true
                    }
                }
            ]
        }
    ]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

router.beforeEach((to: any, from: any, next: any) => {
    if (to.matched.some((r: any) => r.meta.requireAuth)) {
        if(store.state.user.id > 0) {
            next()
        } else {
            store.commit('loadUser')

            if(store.state.user.id > 0) {
                next()
            } else {
                router.push({ name: 'Auth.Login' })
            }
        }
    } else {
        next()
    }
})

export default router
