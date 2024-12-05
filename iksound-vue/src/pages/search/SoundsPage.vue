<script setup>
import {onMounted, ref} from "vue";
import {api} from "../../api.js";
import Searchbar from "../../components/Searchbar.vue";
import {buildTagTree, splitIntoColumns} from "../../tags.js";
import TagItem from "../../components/TagItem.vue";

const genres = ref();

const fetchGenres = () => {
  api.get('json/tags/?sfx_tag=true').then((response) => {
    genres.value = buildTagTree(response.data.genres, 'Genre');
  });
}

onMounted(fetchGenres);
</script>

<template>
  <div class="px-6 lg:px-24">
    <h3 class="text-3xl">Sound Effects</h3>
    <Searchbar is-sfx/>

    <div class="mt-8 fade-in" v-if="genres">
      <h2 class="text-3xl">Genres</h2>
      <div class="flex flex-row mt-2 w-full flex-wrap gap-4 px-px">
        <ul class="col-auto flex-grow" v-for="(column, index) in splitIntoColumns(genres, 3)" :key="'genre-'+index">
          <TagItem v-for="genre in column" :key="genre.id" :tag="genre" class="mt-2" type="genre"></TagItem>
        </ul>
      </div>
    </div>
  </div>
  
</template>

<style scoped>

</style>