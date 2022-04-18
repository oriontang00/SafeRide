<template>
  <div id="mapFooter">
    <button id="routeAnalysisButton" @click="doRouteAnalysisButtonClick">Route Analysis</button>
    <button id="hazardButton" @click="doHazardButtonClick">Report Hazard</button>
    <MapOverlay @selectedColor="onOverlayColorChange" @selectedDim="onOverlaySelect"></MapOverlay>
  </div>
</template>

<script>
import MapOverlay from './MapOverlay'
export default { // OVERLAYS NEEDS TO BE PASSED DYNAMICALLY, cant do rn
  components: {
    MapOverlay
  },
  name: 'MapFooter',
  methods: {
    doRouteAnalysisButtonClick () {
    },
    doHazardButtonClick () {
    },
    onOverlaySelect (value) {
      this.$emit('selectedDimFooter', value)
    },
    onOverlayColorChange (value) {
      this.$emit('selectedOverlayColor', value)
    }
  }
}
</script>

<style scoped>
  #routeAnalysisButton{
    position: relative;
    height: 40px;
    width: 100px;
    background-color: greenyellow;
    right: 20%;
  }
  #hazardButton{
    position: relative;
    height: 40px;
    width: 100px;
    background-color: greenyellow;
    left: 20%;
  }
  #mapFooter{
    height: 50px;
    background-color: gray;
  }
</style>
