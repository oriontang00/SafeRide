<template>
  <div id="mapSearchBox">
    <form>
      <input type="text" id="startLocation" placeholder="Start Location"><br>
      <input v-on:keyup.enter="onSearchEnter" type="text" id="destinationLocation" placeholder="Destination Location"><br>
      <input type="submit" hidden />
    </form>
  </div>
</template>

<script>
export default {
  name: 'MapSearchRectangle',
  methods: {
    onSearchEnter: function () {
      console.log('test')
    }
  }
}
</script>

<style scoped>

</style>
