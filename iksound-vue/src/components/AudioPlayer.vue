<script setup>
import {onBeforeUnmount, onMounted, onUnmounted, ref, watch} from "vue";

const props = defineProps({
  audioUrl: String,
  playing: Boolean
});

const audio = ref();
const progress = ref(0);
let animationFrameId;

const play = () => {
  audio.value.play();
  updateProgress();
};

const updateProgress = () => {
  if (!audio.value || audio.value.paused) return;
  
  progress.value = audio.value.currentTime / audio.value.duration || 0;
  animationFrameId = requestAnimationFrame(updateProgress);
};

const stopProgress = () => {
  props.playing = false;
  cancelAnimationFrame(animationFrameId);
};

onMounted(() => {
  audio.value.addEventListener('play', updateProgress);
  audio.value.addEventListener('pause', stopProgress);
  audio.value.addEventListener('ended', stopProgress);
  
  if (props.playing) {
    play();
  }
});

onBeforeUnmount(() => {
  stopProgress();
  audio.value.removeEventListener('play', updateProgress);
  audio.value.removeEventListener('pause', stopProgress);
  audio.value.removeEventListener('ended', stopProgress);
});

watch(() => props.playing, (newVal) => {
  if (newVal) {
    play();
  } else {
    audio.value.pause();
  }
});
</script>

<template>
  <div class="w-full relative">
    <span class="h-full absolute z-10 w-px bg-white top-0 left-0 smooth-move" :style="`left: ${progress * 100}%;`"></span>
  </div>
    
  <audio :src="audioUrl" type="audio/mpeg" preload="none" ref="audio"/>
</template>

<style scoped>
</style>