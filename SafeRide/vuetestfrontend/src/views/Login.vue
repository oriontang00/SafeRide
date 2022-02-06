<template>
  <div id="app">

    <div class="login-page">
      <transition name="fade">
        <div v-if="!registerActive" class="wallpaper-login"></div>
      </transition>
      <div class="wallpaper-register"></div>

      <div class="container">
        <div class="row">
          <div class="col-lg-4 col-md-6 col-sm-8 mx-auto">
            <div v-if="!registerActive" class="card login" v-bind:class="{ error: emptyFields }">
              <h1>Sign In</h1>
              <form class="form-group">
                <input v-model="emailLogin" type="email" class="form-control" placeholder="Email" required>
                <input v-model="passwordLogin" type="password" class="form-control" placeholder="Password" required>
                <input type="submit" class="btn btn-primary" @click="doLogin">
                <p>
                  Don't have an account? <a href="#" @click="registerActive = !registerActive, emptyFields = false">Sign up here</a>
                </p>
              </form>
            </div>
          </div>
        </div>

      </div>
    </div>

  </div>
</template>

<script>
import axios from 'axios'
export default {
  el: '#app',
  name: 'Home',
  methods: {
    doLogin () {
      const data = JSON.stringify({
      })

      console.log(data)

      if (this.emailLogin !== undefined && this.passwordLogin !== undefined) {
        axios.post('https://localhost:5001/api/login', {
          UserName: this.emailLogin,
          Password: this.passwordLogin
        })
          .then(function (response) {
            var token = response.data.token
            axios.defaults.headers.common.Authorization = 'Bearer ' + response.data.token
            localStorage.setItem('token', JSON.stringify(token))
            console.log(response)
            window.alert('login success with token = ' + localStorage.getItem('token'))
          })
          .catch(function (error) {
            console.log(error)
          })
      }
    }
  }
}

</script>
