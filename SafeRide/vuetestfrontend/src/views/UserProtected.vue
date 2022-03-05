<template>
  <div class="UserProtected">
    <div v-if=loggedin>
      <h1>Welcome, </h1>
    </div>
    <div v-else>
      <h1>User protected page</h1>
    </div>
    <button></button>
  </div>
</template>

<script>
import axios from 'axios'

async function getUserInfo () {
  axios.defaults.headers.common.Authorization = 'Bearer ' + localStorage.getItem('token')
  const res = await axios.post('https://localhost:5001/api/getToken')
    .then(function (response) { // do something with token here
      return true
    })
    .catch(function () {
      return false
    })
  return res
}

export default {
  data () {
    return {
      loggedin: getUserInfo()
    }
  }
}
</script>
