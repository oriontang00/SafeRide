<template>
  <div id="app">
    <h1>Sign In</h1>
    <form class="form-group">
      <input v-model="userLogin" type="text" class="form-control" placeholder="Username" required>
      <input v-model="emailLogin" type="text" class="form-control" placeholder="Email" required>
      <input type="submit" class="btn btn-primary" @click="doLogin">
    </form>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  el: '#app',
  name: 'Home',
  methods: {
    doLogin () {
      if (this.userLogin !== undefined && this.emailLogin !== undefined) {
        axios.post('https://backendsaferideapi.azure-api.net/overlayAPI/api/login', {
          UserName: this.userLogin,
          Email: this.emailLogin,
          Role: 'Admin',
          Valid: true
        }, {
          withCredentials: true
        })
          .then(function (response) {
            var token = response.data.token
            localStorage.setItem('token', JSON.stringify(token))
            console.log(response)
            window.alert('login success with token = ' + localStorage.getItem('token'))
          })
          .catch(function (error) {
            console.log(error)
            window.alert('Login error')
          })
      }
    }
  }
}

</script>
