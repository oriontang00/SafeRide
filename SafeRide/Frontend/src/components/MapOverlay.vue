<template>
  <div id="overlayColors">
    <h3>Overlay color selection</h3>
    <select v-model="selectedColor">
      <option v-for="overlayColor in possibleColors" v-bind:key="overlayColor.value">
        {{overlayColor}}
      </option>
      <option>
        Default
      </option>
    </select>
  </div>
  <div id="overlayButtons" >
    <h1>Overlay</h1>
    <select v-model="selectedOverlay">
      <option v-for="overlayName in possibleOverlays" v-bind:key="overlayName.value">
        {{overlayName}}
      </option>
      <option>
        None
      </option>
    </select>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  components: {
  },
  name: 'MapOverlay',
  data () {
    return {
      possibleOverlays: {},
      selectedOverlay: '',
      overlayDims: [],
      selectedColor: '',
      possibleColors: ['red', 'yellow', 'grey', 'blue', 'purple', 'green']
    }
  },
  methods: {
    async getOverlays () {
      let overlays = []
      axios.defaults.headers.common.Authorization = localStorage.getItem('token')
      await axios.get('https://backendsaferideapi.azure-api.net/overlayAPI/api/overlay/all', {
        withCredentials: true
      })
        .then(async function (res) { // do something with res here
          overlays = await res
        })
        .catch(function () {
        })
      return overlays.data.overlays
    },
    async getOverlayDim (selOverlay) {
      let overlayDim = []
      axios.defaults.headers.common.Authorization = localStorage.getItem('token')
      await axios.get('https://backendsaferideapi.azure-api.net/overlayAPI/api/overlay/dim', { withCredentials: true, params: { overlayName: selOverlay } })
        .then(async function (res) {
          overlayDim = await res
        })
        .catch(function () {
        })
      return overlayDim.data
    }
  },
  created () {
    this.getOverlays().then((res) => {
      this.possibleOverlays = res
    })
  },
  updated () {
    if (this.selectedOverlay !== 'None' && this.selectedOverlay !== '') {
      console.log(this.selectedOverlay)
      this.getOverlayDim(this.selectedOverlay).then((res) => {
        if (this.selectedColor === 'Default') {
          this.$emit('selectedDim', res)
        } else {
          res.overlayColor = this.selectedColor
          this.$emit('selectedDim', res)
        }
      })
    }
    if (this.selectedOverlay === 'None') {
      this.$emit('selectedDim', 'None')
    }
  }
}
</script>

<style scoped>
  #overlayButtons{
    position: relative;
    width: 100px;
    bottom: 300px;
  }
  #overlayColors{
    position: relative;
    width: 100px;
    bottom: 500px;
  }
</style>
