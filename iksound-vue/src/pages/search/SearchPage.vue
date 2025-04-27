<script setup>

import {onBeforeUnmount, onMounted, ref} from "vue";
import {api} from "../../api.js";
import {useRoute} from "vue-router";
import TrackComponent from "../../components/TrackListItem.vue";

const route = useRoute();

const tracks = ref([]);
const playingTrack = ref(null);
const audio = ref();
const playing = ref(false);
const progress = ref(0);
const page = ref(1);
const loading = ref(false);
const totalPages = ref(-1);
const totalHits = ref(-1);
const headGenre = ref('');
const subGenre = ref('');

let animationFrameId;

const loadTracks = async (page) => {
  loading.value = true;
  
  const type = route.query.sfx.toLowerCase() === 'true' ? 'sfx' : 'tracks';
  const term = route.query.term;
  const genre = route.query.genre;
  const mood = route.query.mood;

  api.get(`json/search/${type}/?`, {
    params: {
      page: page,
      limit: 15,
      term: term,
      genres: genre,
      moods: mood,
      sort: 'relevance',
      order: 'desc'
    }
  })
  .then((response) => {
    const newTracks = Object.values(response.data.entities.tracks);
    tracks.value.push(...newTracks);
    loading.value = false;
    
    totalPages.value = response.data.meta.totalPages;
    totalHits.value = response.data.meta.totalHits;
    
    if (genre) {
      const genres = response.data.meta.aggregations.genres;
      
      headGenre.value = genres[0]?.displayKey;
      subGenre.value = genres.find(g => g.key === genre)?.displayKey;
    }
  });
}

const playTrack = (track) => {
  playingTrack.value = track;
  
  if (audio.value) {
    if (audio.value.src === track.stems.full.lqMp3Url) {
      audio.value.play();
      playing.value = true;
    } else {
      audio.value.src = track.stems.full.lqMp3Url;

      audio.value.currentTime = 0;
      progress.value = 0;
      audio.value.play();
      playing.value = true;
    }
    
    updateProgress();
  }
}

const playAt = (track, at) => {
  if (audio.value) {
    progress.value = at;
    audio.value.src = track.stems.full.lqMp3Url;
    audio.value.play();

    audio.value.currentTime = at * track.durationMs / 1000;
    playing.value = true;
    playingTrack.value = track;
    updateProgress();
  }
}

const pauseTrack = () => {
  if (audio.value) {
    audio.value.pause();
    playing.value = false;
    stopProgress();
  }
}

const updateProgress = () => {
  if (!audio.value || audio.value.paused) return;

  
  if (!isNaN(audio.value.duration))
    progress.value = audio.value.currentTime / audio.value.duration || 0;
  
  animationFrameId = requestAnimationFrame(updateProgress);
};

const stopProgress = () => {
  cancelAnimationFrame(animationFrameId);
};

const onEnded = () => {
  playing.value = false;
  stopProgress();
}

const handleScroll = (e) => {
  const scrollPosition = document.documentElement.scrollTop || document.body.scrollTop;
  const scrollHeight = document.documentElement.scrollHeight || document.body.scrollHeight;
  const clientHeight = document.documentElement.clientHeight || document.body.clientHeight;
  const dist = scrollHeight - (scrollPosition + clientHeight)
  
  if(dist <= 0) {
    loadMore();
  }
}

const loadMore = () => {
  if (loading.value)
    return;
  
  page.value++;
  loadTracks(page.value)
}

onMounted(() => {
  loadTracks(page.value);

  audio.value.addEventListener('play', updateProgress);
  audio.value.addEventListener('pause', stopProgress);
  audio.value.addEventListener('ended', onEnded);
  
  document.onscroll = handleScroll;
});

onBeforeUnmount(() => {
  stopProgress();
  audio.value.removeEventListener('play', updateProgress);
  audio.value.removeEventListener('pause', stopProgress);
  audio.value.removeEventListener('ended', onEnded);
  
  document.onscroll = null;
});
</script>

<template>
<audio ref="audio"/>
<div class="2xl:px-16">

  <h1 v-if="route.query.genre && headGenre" class="fade-in text-secondary !text-lg my-2">
    {{ route.query.sfx.toLowerCase() === 'true' ? 'Sound Effects' : 'Music' }}
    /
    {{ headGenre }}
    {{ subGenre !== headGenre ? `/ ${subGenre}` : '' }}
  </h1>
  <h1 v-else-if="route.query.term && totalHits > 0" class="fade-in text-secondary !text-lg my-2">
    <span class="text-gray-300">{{totalHits}}</span> results for <i class="text-gray-300">"{{route.query.term}}"</i>
  </h1>

  <div v-if="totalPages === 0" class="fade-in w-full text-center">
    <strong>No results found...</strong>
    <p class="text-secondary">Try searching something else</p>
  </div>
  
  <ul class="flex flex-col gap-2">
    <li v-for="track in tracks" :key="track.id">
      <TrackComponent :track="track" @play="playTrack(track)" @pause="pauseTrack" @play-at="(at) => playAt(track, at)" :play-progress="playingTrack === track ? progress : null" :playing="playingTrack === track && playing"/>
    </li>
  </ul>
  
  <button v-if="tracks.length !== 0 && totalPages > page" @click="loadMore" class="fade-in" id="load-more">
    Load more
  </button>
</div>
</template>

<style scoped>
#load-more {
  @apply text-center w-full mt-4 p-1;
  background: #181b1e;
}

#load-more:hover {
  background: #1c1c1c;
}

#load-more:active {
  background: #3b3b3b;
}
</style>