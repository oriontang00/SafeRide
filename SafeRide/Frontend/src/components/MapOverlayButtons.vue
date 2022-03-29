<template>
  <div id="overlayButtons" >
    <Overlay v-for="overlayName in possibleOverlays.overLayNames" v-bind:key="overlayName.key" :overlayNames="overlayName"></Overlay>
  </div>
</template>

<script>
import Overlay from '@/components/Overlay.vue'
export default {
  components: {
    Overlay
  },
  name: 'MapOverlayButtons',
  data () {
    return {
      possibleOverlays: { overLayNames: ['test1', 'test2'] }
    }
  },
  methods: {
  },
  beforeCreated () {
  },
  created () {
  }
}
</script>

<style scoped>
  #overlayButtons{
    position: relative;
    width: 100px;
    bottom: 50px;
  }
</style>
