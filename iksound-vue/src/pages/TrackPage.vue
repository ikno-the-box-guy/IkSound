<script setup>
import {useRoute} from "vue-router";

const route = useRoute();
</script>

<template>
  <h1 class="text-5xl">TODO</h1>
  <p class="text-lg"><span>Slug: </span><i class="text-secondary">{{route.params.id}}</i></p>
</template>

<style scoped>

</style>