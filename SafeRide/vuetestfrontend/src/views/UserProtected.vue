<template>
  <div class="UserProtected">
    <h1>This is user protected page</h1>
  </div>
</template>

<script>
  import axios from 'axios'
  export default {
    getUserInfo() {
      axios.get()
    }
  }
</script>
