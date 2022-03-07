import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import UserProtected from '../views/UserProtected.vue'
import CreateAccount from '../views/CreateAccount.vue'
import DefaultMap from '../views/DefaultMap.vue'

const routes = [
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
    path: '/user',
    name: 'User',
    component: UserProtected
  },
  {
    path: '/createAccount',
    name: 'CreateAccount',
    component: CreateAccount
  },
  {
    path: '/map',
    name: 'Map',
    component: DefaultMap
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
