<template>
  <div id="overlayButtons" v-for="overlay in possibleOverlays" v-bind:key="overlay.key">
    <Overlay overlay={{overlay}}></Overlay>
  </div>
</template>

<script>
import Overlay from '@/components/Overlay.vue'
export default {
  components: {
    Overlay
  },
  name: 'MapOverlayButtons',
  props: {
    possibleOverlays: {
      type: Array
    }
  },
  methods: {
    getOverLays () {
    }
  }
}
</script>

<style scoped>

</style>
