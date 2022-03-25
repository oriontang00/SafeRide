<template>
  <MainMap api_key="test123"></MainMap>
</template>

<script>
import MainMap from '@/components/MainMap'
import axios from 'axios'
export default {
  components: {
    MainMap
  },
  name: 'LoggedInInitialView',
  created () {
    axios.defaults.headers.common.Authorization = localStorage.getItem('token')
    axios.post('https://localhost:5001/getKey')
  }
}
</script>

<style scoped>

</style>
