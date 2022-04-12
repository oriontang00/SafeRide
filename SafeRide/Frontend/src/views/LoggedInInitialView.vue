<template>
  <!--  ""-->
  <MainMap api_key="pk.eyJ1IjoiYXBwbGVmdSIsImEiOiJja3p5dWV1eTkwM3gyM2lteGZqZGszNTBjIn0.CLc4mochtSCflbpW9BPH4Q"></MainMap>
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
  }
}
</script>

<style scoped>

</style>
