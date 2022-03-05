<template>
  <div id="app">
    <h1>Sign In</h1>
    <form class="form-group">
      <input v-model="userLogin" type="text" class="form-control" placeholder="Username" required>
      <input v-model="passwordLogin" type="password" class="form-control" placeholder="Password" required>
      <input type="submit" class="btn btn-primary" @click="doLogin">
    </form>
  </div>
</template>

<script>
import fetch from 'fetch'
export default {
  el: '#app',
  name: 'Home',
  methods: {
    doLogin () {
      if (this.userLogin !== undefined && this.passwordLogin !== undefined) {
        fetch('https://localhost:5001/api/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: {
            UserName: this.userLogin,
            Password: this.passwordLogin
          }
        })
          .then(function (response) {
            const token = response.data.token
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
