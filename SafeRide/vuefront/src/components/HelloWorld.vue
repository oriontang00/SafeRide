<template>
    <div class="post">
        <div>
            SAFRIDE TEST TEXT
        </div>

        <div id="appinfo">
            {{ info }}
        </div>
    </div>
</template>

<script lang="ts">
    import axios from 'axios';
    import Vue from 'vue';
    export default Vue.extend(
    {
        el: "#app",
        data() {
            return {
                info: null
            }
        },

        mounted() {
            axios
                .get('https://api.coindesk.com/v1/bpi/currentprice.json')
                .then(response => (this.info = response.data.bpi))
        }
    })

</script>