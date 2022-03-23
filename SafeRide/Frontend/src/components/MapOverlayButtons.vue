<template>
  <div id="overlayButtons" v-for="overlay in possibleOverlays">
    <Overlay overlay={{overlay}}></Overlay>
  </div>
</template>

<script>
import Overlay from "@/components/Overlay.vue"
export default {
  components: {
    Overlay
  },
  name: "MapOverlayButtons",
  props:{
    possibleOverlays: {
      type: Array
    }
  },
  methods:{
    getOverLays () {
      this.possibleOverlays = ["test1", "test2", "test3"]
    }
  }
}
</script>

<style scoped>

</style>
