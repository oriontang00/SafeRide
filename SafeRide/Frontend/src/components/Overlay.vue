<template>
  <div id="singleOverlay">
    <button>{{overlay.overLayName}}</button>
  </div>

</template>

<script>
export default {
  name: "Overlay",
  props:{
    overlay:{
      type: Object,
      overLayName: String
    }
  }
}
</script>

<style scoped>

</style>
