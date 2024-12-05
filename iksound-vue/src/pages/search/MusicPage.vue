<script setup>
import {onMounted, ref} from "vue";
import {api} from "../../api.js";
import Searchbar from "../../components/Searchbar.vue";
import TagItem from "../../components/TagItem.vue";
import {buildTagTree, splitIntoColumns} from "../../tags.js";

const genres = ref();
const moods = ref();

const genresVisible = ref(true);

const fetchGenres = () => {
  api.get('json/tags/?sfx_tag=false').then((response) => {
    genres.value = buildTagTree(response.data.genres, 'Genre');
    moods.value = buildTagTree(response.data.moods, 'Mood');
  });
}

onMounted(fetchGenres);
</script>

<template>
  <div class="px-6 lg:px-24">
    <h3 class="text-3xl">Search Music</h3>
    <Searchbar/>

    <div class="mt-8 fade-in" v-if="moods && genres">
      <div class="flex flex-row justify-between items-baseline">
        <h2 class="text-3xl">{{genresVisible ? 'Genres' : 'Moods'}}</h2>
        <button class="clickable-link text-secondary" @click="genresVisible = !genresVisible">Switch genre/mood</button>
      </div>
      <div class="flex flex-row mt-2 w-full flex-wrap gap-4 px-px">
        <ul :class="[{'hidden': !genresVisible},'col-auto flex-grow']" v-for="(column, index) in splitIntoColumns(genres, 3)" :key="'genre-'+index">
          <TagItem v-for="genre in column" :key="genre.id" :tag="genre" class="mt-2" type="genre"></TagItem>
        </ul>
        <ul :class="[{'hidden': genresVisible},'col-auto flex-grow']" v-for="(column, index) in splitIntoColumns(moods, 3)" :key="'mood-'+index">
          <TagItem v-for="mood in column" :key="mood.id" :tag="mood" class="mt-2" type="mood"></TagItem>
        </ul>
      </div>
    </div>
  </div>
</template>

<style scoped>

</style>