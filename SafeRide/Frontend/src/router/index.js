import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import UserProtected from '../views/UserProtected.vue'
import UserRegistration from '../views/UserRegistration.vue'
import DefaultMap from '../views/DefaultMap.vue'
import AnalysisDashboard from '../views/AnalysisDashboard.vue'

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
    path: '/UserRegistration',
    name: 'UserRegistration',
    component: UserRegistration
  },
  {
    path: '/user',
    name: 'User',
    component: UserProtected
  },
  {
    path: '/map',
    name: 'Map',
    component: DefaultMap
  },
  {
    path: '/analytics',
    name: 'Analytics',
    component: AnalysisDashboard
  }

]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
