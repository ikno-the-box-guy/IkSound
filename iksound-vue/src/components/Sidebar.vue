<script setup>
import {computed} from "vue";
import {useRoute} from "vue-router";
import corsProxy from "../corsSetting.js";

const route = useRoute();

const isActive = (path) => {
  return computed(() => route.path === path);
};
</script>

<template>
  <div class="h-full flex flex-col">
    <div class="bg-black bg-opacity-40 h-14 flex items-center pl-6">
      <div class="flex items-center justify-between">
        <RouterLink class="text-white text-lg" to="/">IkSound</RouterLink>
      </div>
    </div>
  
    <div class="px-2 py-4 sm:w-60 grow">
      <nav class="flex flex-col px-2 gap-2 h-full">
        <RouterLink :class="[{'nav-item-active': isActive('/').value}, 'nav-item']" to="/">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="size-6">
            <path fill-rule="evenodd" d="M9.293 2.293a1 1 0 0 1 1.414 0l7 7A1 1 0 0 1 17 11h-1v6a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1v-3a1 1 0 0 0-1-1H9a1 1 0 0 0-1 1v3a1 1 0 0 1-1 1H5a1 1 0 0 1-1-1v-6H3a1 1 0 0 1-.707-1.707l7-7Z" clip-rule="evenodd" />
          </svg>
  
          Home
        </RouterLink>
        <RouterLink :class="[{'nav-item-active': isActive('/sounds').value}, 'nav-item']" to="/sounds">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="size-6">
            <path d="M13.5 4.06c0-1.336-1.616-2.005-2.56-1.06l-4.5 4.5H4.508c-1.141 0-2.318.664-2.66 1.905A9.76 9.76 0 0 0 1.5 12c0 .898.121 1.768.35 2.595.341 1.24 1.518 1.905 2.659 1.905h1.93l4.5 4.5c.945.945 2.561.276 2.561-1.06V4.06ZM18.584 5.106a.75.75 0 0 1 1.06 0c3.808 3.807 3.808 9.98 0 13.788a.75.75 0 0 1-1.06-1.06 8.25 8.25 0 0 0 0-11.668.75.75 0 0 1 0-1.06Z" />
            <path d="M15.932 7.757a.75.75 0 0 1 1.061 0 6 6 0 0 1 0 8.486.75.75 0 0 1-1.06-1.061 4.5 4.5 0 0 0 0-6.364.75.75 0 0 1 0-1.06Z" />
          </svg>
  
          Sound Effects
        </RouterLink>
        <RouterLink :class="[{'nav-item-active': isActive('/music').value}, 'nav-item']" to="/music">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor" class="size-6">
            <path fill-rule="evenodd" d="M19.952 1.651a.75.75 0 0 1 .298.599V16.303a3 3 0 0 1-2.176 2.884l-1.32.377a2.553 2.553 0 1 1-1.403-4.909l2.311-.66a1.5 1.5 0 0 0 1.088-1.442V6.994l-9 2.572v9.737a3 3 0 0 1-2.176 2.884l-1.32.377a2.553 2.553 0 1 1-1.402-4.909l2.31-.66a1.5 1.5 0 0 0 1.088-1.442V5.25a.75.75 0 0 1 .544-.721l10.5-3a.75.75 0 0 1 .658.122Z" clip-rule="evenodd" />
          </svg>
  
          Music
        </RouterLink>
        
        <div class="mt-auto">
          <RouterLink to="/cors" class="text-secondary text-sm clickable-link">CORS proxy url</RouterLink>
          <input type="text" v-model="corsProxy" class="w-full truncate border-opacity-30 text-opacity-30 focus:border-opacity-100 focus:text-opacity-100 border border-gray-400 outline-0 rounded px-4 py-2 bg-gray-600 bg-opacity-10 text-white"/>
        </div>
      </nav>
    </div>
  </div>
  
</template>

<style scoped>
.nav-item {
  @apply rounded py-3 px-2 hover:text-white hover:bg-white hover:bg-opacity-10 flex flex-row gap-2;
  transition: background-color 0.1s ease;
}

.nav-item-active {
  @apply bg-white bg-opacity-35 text-white;
}
</style>