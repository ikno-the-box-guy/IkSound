<script setup>
import {onMounted, ref} from "vue";
import {api} from "../../api.js";
import GenreItem from "../../components/GenreItem.vue";
import Searchbar from "../../components/Searchbar.vue";

const genres = ref();

const buildGenreTree = (flatGenres) => {
  const genreMap = new Map();

  flatGenres.forEach((genre) => {
    genre.children = [];
    genreMap.set(genre.id, genre);
  });

  const tree = [];

  flatGenres.forEach((genre) => {
    if (genre.fatherGenreId && genreMap.has(genre.fatherGenreId)) {
      genreMap.get(genre.fatherGenreId).children.push(genre);
    } else {
      tree.push(genre); // No parent or parent not found, add to root
    }
  });

  return tree;
}

const splitIntoColumns = (items, numColumns) => {
  const columns = Array.from({ length: numColumns }, () => []);
  items.forEach((item, index) => {
    columns[index % numColumns].push(item);
  });
  return columns;
}

const fetchGenres = () => {
  api.get('json/tags/?sfx_tag=false').then((response) => {
    genres.value = buildGenreTree(response.data.genres);
  });
}

onMounted(fetchGenres);
</script>

<template>
  <div class="px-6 lg:px-24">
    <h3 class="text-3xl">Music</h3>
    <Searchbar/>

    <div class="flex flex-row mt-2 w-full flex-wrap gap-4" v-if="genres">
      <ul class="fade-in col-auto flex-grow" v-for="(column, index) in splitIntoColumns(genres, 3)" :key="index">
        <GenreItem v-for="genre in column" :key="genre.id" :genre="genre" class="mt-2"></GenreItem>
      </ul>
    </div>
  </div>

</template>

<style scoped>

</style>