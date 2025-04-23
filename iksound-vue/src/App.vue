<script setup>
import Sidebar from "./components/Sidebar.vue";
import {useRoute} from "vue-router";

const route = useRoute();
</script>

<template>
  <div class="relative flex flex-col sm:flex-row">
    <div class="bg-sidebar sm:w-60 sm:h-screen sm:sticky sm:top-0">
      <Sidebar/>
    </div>

    <main class="flex-1">
      <div class="bg-black bg-opacity-20 justify-between sm:justify-end h-14 flex items-center px-4 sticky top-0 z-10">
        <a href="https://github.com/ikno-the-box-guy/IkSound" target="_blank" class="text-blue-500 hover:underline">About</a>
      </div>

      <article class="py-4 px-6">
        <RouterView  :key="route.fullPath"/>
      </article>
    </main>
  </div>
</template>

<style scoped>
.bg-sidebar {
  background-image: linear-gradient(180deg, #004346 0%, #172A3A 70%);
}
</style>
