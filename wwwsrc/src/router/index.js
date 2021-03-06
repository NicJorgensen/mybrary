import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from '@/components/Home'
// @ts-ignore
import Login from '@/components/Login'
// @ts-ignore
import Profile from '@/components/Profile'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/login',
      name: 'Login',
      component: Login
    },
    {
      path: '/profile',
      name: 'Profile',
      component: Profile
    }
  ]
})
