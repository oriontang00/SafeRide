<template>
  <div id="mapFooter">
    <button id="routeAnalysisButton" @click="doRouteAnalysisButtonClick">Route Analysis</button>
    <button id="hazardButton" @click="doHazardButtonClick">Report Hazard</button>
    <MapOverlayButtons></MapOverlayButtons>
  </div>
</template>

<script>
import MapOverlayButtons from './MapOverlayButtons'
export default { // OVERLAYS NEEDS TO BE PASSED DYNAMICALLY, cant do rn
  components: {
    MapOverlayButtons
  },
  name: 'MapFooter',
  methods: {
    doRouteAnalysisButtonClick () {
    },
    doHazardButtonClick () {
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
