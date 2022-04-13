<template>
  <MapHeader></MapHeader>
  <MapSearchRectangle id="MapSearchRec"></MapSearchRectangle>
  <div id='map'></div>
  <MapFooter @selectedDimFooter="onReceiveOverlay"></MapFooter>
</template>

<script>
import MapSearchRectangle from '@/components/MapSearchRectangle'
import MapHeader from '@/components/MapHeader.vue'
import MapFooter from '@/components/MapFooter'
import 'mapbox-gl/dist/mapbox-gl.css'
import mapboxgl from 'mapbox-gl'
export default {
  components: {
    MapSearchRectangle,
    MapFooter,
    MapHeader
  },
  methods: {
    removeOverlays () {
      if (this.map.getLayer('maine')) {
        this.map.removeLayer('maine')
      }
      if (this.map.getLayer('outline')) {
        this.map.removeLayer('outline')
      }
      if (this.map.getSource('maine')) {
        this.map.removeSource('maine')
      }
    },
    addOverlays (value) {
      const coords = []
      value.forEach(function (coord) {
        coords.push([coord.latPoint, coord.longPoint])
      })
      this.map.addSource('maine', {
        type: 'geojson',
        data: {
          type: 'Feature',
          geometry: {
            type: 'Polygon',
            coordinates: [
              coords
            ]
          }
        }
      })
      this.map.addLayer({
        id: 'maine',
        type: 'fill',
        source: 'maine', // reference the data source
        layout: {},
        paint: {
          'fill-color': '#0080ff', // blue color fill
          'fill-opacity': 0.5
        }
      })
      this.map.addLayer({
        id: 'outline',
        type: 'line',
        source: 'maine',
        layout: {},
        paint: {
          'line-color': '#000',
          'line-width': 3
        }
      })
    },
    onReceiveOverlay (value) {
      if (value !== 'None') {
        this.removeOverlays()
        this.addOverlays(value)
      } else {
        this.removeOverlays()
      }
    }
  },
  props: ['api_key'],
  mounted () {
    mapboxgl.accessToken = this.api_key
    this.map = new mapboxgl.Map({
      container: 'map', // container ID
      style: 'mapbox://styles/mapbox/streets-v11', // style URL
      center: [-118.1109043, 33.7827241], // starting position [lng, lat]
      zoom: 14 // starting zoom
    })
  }
}
</script>

<style scoped>
#map{
  margin: auto;
  width: 70%;
  height: 600px;
}
#MapSearchRec{
  position:fixed;
  left:50px;
}
</style>
