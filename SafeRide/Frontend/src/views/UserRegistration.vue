<template>
  <div class="UserRegistration">
    <h1>Registration</h1>
    <p>Enter desired Username, Email, and passphrase</p>
    <form class="form-group">
      <input v-model="userName" type="text" class="form-control" placeholder="Username" required>
      <input v-model="userEmail" type="text" class="form-control" placeholder="Email Address" required>
      <input v-model="userOTP" type="text" class="form-control" placeholder="Passphrase" required>
      <input type="submit" class="btn btn-primary" @click="doRegistration">
    </form>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  el: 'app',
  name: 'Home',
  methods: {
    doRegistration () {
      if (this.userName !== undefined && this.userEmail !== undefined && this.userOTP !== undefined) {
        axios.post('https://backendsaferideapi.azure-api.net/user/CreateUser', {
          Username: this.userName,
          Email: this.userEmail,
          Passphrase: this.userTOP,
          Role: 'User',
          Valid: true
        })
          .then(function (response) {
            console.log(response)
            window.alert('Email confirmation pending')
          })
          .catch(function (error) {
            console.log(error)
            window.alert('Account creation error. Retry again or contact system administrator')
          })
      }
    }
  }
}
</script>
