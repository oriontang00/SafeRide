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
    onReceiveOverlay (value) {
      console.log('mainMap' + value)
      this.map.addSource('maine', {
        type: 'geojson',
        data: {
          type: 'Feature',
          geometry: {
            type: 'Polygon',
            coordinates: [
              [
                [-67.13734, 45.13745],
                [-66.96466, 44.8097],
                [-68.03252, 44.3252],
                [-69.06, 43.98],
                [-70.11617, 43.68405],
                [-70.64573, 43.09008],
                [-70.75102, 43.08003],
                [-70.79761, 43.21973],
                [-70.98176, 43.36789],
                [-70.94416, 43.46633],
                [-71.08482, 45.30524],
                [-70.66002, 45.46022],
                [-70.30495, 45.91479],
                [-70.00014, 46.69317],
                [-69.23708, 47.44777],
                [-68.90478, 47.18479],
                [-68.2343, 47.35462],
                [-67.79035, 47.06624],
                [-67.79141, 45.70258],
                [-67.13734, 45.13745]
              ]
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
