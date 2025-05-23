﻿<script setup>
import {onMounted, ref} from "vue";
import WaveformData from "https://cdn.jsdelivr.net/npm/waveform-data@4.5.0/dist/waveform-data.esm.min.js";

const props = defineProps({
  waveformUrl: String
});

const waveformCanvas = ref();

const loadWaveformData = async () => {
  const response = await fetch(props.waveformUrl);
  return await response.json();
}

const drawWaveform = (waveformJson, canvas) => {
  let waveform = new WaveformData(waveformJson);

  const scaleY = (amplitude, height) => {
    const range = 256;
    const offset = 128;

    return height - ((amplitude + offset) * height) / range;
  }

  const ctx = canvas.getContext('2d');
  ctx.beginPath();

  const channel = waveform.channel(0);

  // Loop forwards, drawing the upper half of the waveform
  for (let x = 0; x < waveform.length; x++) {
    const val = channel.max_sample(x);

    ctx.lineTo(Math.fround(x + 0.5), Math.fround(scaleY(val, canvas.height) + 0.5));
  }

  // Loop backwards, drawing the lower half of the waveform
  for (let x = waveform.length - 1; x >= 0; x--) {
    const val = channel.min_sample(x);

    ctx.lineTo(Math.fround(x + 0.5), Math.fround(scaleY(val, canvas.height) + 0.5));
  }

  ctx.closePath();

  ctx.strokeStyle = '#4B4E55';
  ctx.fillStyle = '#4B4E55';

  ctx.stroke();
  ctx.fill();
}

onMounted(async () => {
  const waveform = await loadWaveformData();
  drawWaveform(waveform, waveformCanvas.value);
});
</script>

<template>
<canvas width="1600" height="194" class="h-full w-full absolute color-waveform" ref="waveformCanvas"/>
</template>

<style scoped>
.color-waveform{
  color: #16191b;
}
</style>