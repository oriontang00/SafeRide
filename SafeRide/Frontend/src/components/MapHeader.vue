<template>
  <div id="mapHeader">
    <button id="homeButton" @click="doHomeButtonClick">Home Button</button>
    <button id="savedRoutesButton" @click="doSavedRoutesButtonClick">Saved Routes</button>
    <button id="accountButton" @click="doAccountButtonClick">Account</button>

  </div>
</template>

<script>
export default {
  name: 'MapHeader',
  methods: { // put your logic here :)
    doHomeButtonClick () {
    },
    doSavedRoutesButtonClick () {
    },
    doAccountButtonClick () {
    }
  }
}
</script>

<style scoped>
  #homeButton{
    position: relative;
    right: 25%;
    width: 100px;
    height: 40px;
    background-color: greenyellow;
  }
  #savedRoutesButton{
    position: relative;
    left: 25%;
    width: 100px;
    height: 40px;
    background-color: greenyellow;
  }
  #accountButton{
    position: relative;
    left: 30%;
    width: 100px;
    height: 40px;
    background-color: greenyellow;
  }
  #mapHeader{
    height: 50px;
    background: gray;
  }

</style>
