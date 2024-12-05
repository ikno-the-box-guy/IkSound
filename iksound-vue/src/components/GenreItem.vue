<script setup>
const props = defineProps({
  genre: {
    displayTag: String,
    slug: String,
    numTracks: Number
  },
  isSfx: Boolean
})

</script>

<template>
  <li>
    <RouterLink :to="`/search?genre=${genre.slug}&sfx=${isSfx}`" class="clickable-link">{{ genre.displayTag }}</RouterLink>
    <ul v-if="genre.children.length">
      <GenreItem v-for="child in genre.children" :key="child.id" :genre="child" class="sub-genre" :is-sfx="isSfx"></GenreItem>
    </ul>
  </li>
</template>

<style scoped>
.sub-genre {
  color: rgba(222, 226, 230, 0.5);
}
</style>