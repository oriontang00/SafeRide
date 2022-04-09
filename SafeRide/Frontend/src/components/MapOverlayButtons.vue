<template>
  <div id="overlayButtons" >
    <Overlay v-for="overlayName in possibleOverlays" v-bind:key="overlayName.key" :overlayNames="overlayName"></Overlay>
  </div>
</template>

<script>
import Overlay from '@/components/Overlay.vue'
import axios from 'axios'
export default {
  components: {
    Overlay
  },
  name: 'MapOverlayButtons',
  data () {
    return {
      possibleOverlays: {}
    }
  },
  methods: {
    async getOverlays () {
      let overlays = []
      axios.defaults.headers.common.Authorization = localStorage.getItem('token')
      await axios.get('https://localhost:5001/api/overlay/all')
        .then(async function (res) { // do something with res here
          overlays = await res
        })
        .catch(function () {
        })
      return overlays.data.overlays
    }
  },
  created () {
    this.getOverlays().then((res) => {
      this.possibleOverlays = res
    })
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
