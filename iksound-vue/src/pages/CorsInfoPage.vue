<script setup>
import {useRoute} from "vue-router";

const route = useRoute()
</script>

<template>
<div class="px-8">
  <div v-if="route.query.error" class="mb-4 border border-red-700 rounded-lg p-4 bg-red-600 bg-opacity-30  flex-row">
    <h4>Oops, an error occurred while fetching, probably cors related...</h4>
    <p>Try changing your cors proxy using the instructions below.</p>
    <p v-if="route.query.from" class="mt-4">
      Updated your proxy: <a :href="route.query.from">Go back</a>
    </p>
  </div>
  
  <h1>What is CORS and why should I care?</h1>
  
  <p class="mt-4">
    CORS stands for Cross-Origin Resource Sharing. It is a security feature implemented by browsers to prevent malicious websites from making requests to other websites on your behalf. This is important because it prevents attackers from stealing your data or performing actions on your behalf without your consent.
  </p>
  
  <p class="mt-4">
    The problem is, we actually do need to make a request to an API that is hosted on a different domain. We can get around this by using a <span class="!text-white italic">proxy server</span>. A proxy server is a server that sits between your client and the API server. When you make a request to the proxy server, it forwards the request to the API server on your behalf. Since the request is coming from the proxy server, the browser does not block it.
  </p>
  
  <p class="mt-4 italic !text-white">
    TL;DR: Website doesn't work without a CORS proxy.
  </p>
  
  <h1 class="mt-8">Picking a CORS proxy</h1>
  <p class="mt-4">You could use a publicly available CORS proxy, or you could <a href="https://hub.docker.com/r/redocly/cors-anywhere">host one yourself</a>.</p>

  <p class="mt-4">Here are some CORS proxies you could use:</p>
  
  <ul class="mt-4 list-disc ml-5">
    <li><a href="https://corsproxy.io/">https://corsproxy.io/?</a> <span class="text-gray-500">(recommended, seems to have a caching issue though)</span></li>
    <li><a href="https://cors-anywhere-64h4.onrender.com/">https://cors-anywhere-64h4.onrender.com/</a> <span class="text-gray-500">(my proxy, may take a few seconds to start up if no requests have been made in a while)</span></li>
    <li><a href="https://corsproxy.github.io/">https://crossorigin.me/</a> <span class="text-gray-500">(meant for development only)</span></li>
  </ul>
  
  <p class="mt-4">Use these by copying the text content and putting them in the text box at the bottom of the sidebar, or click on them to read more about these specific proxies.</p>
</div>
</template>

<style scoped>
h1 {
  @apply text-3xl font-bold;
}

h4 {
  @apply text-xl font-bold;
}

p {
  @apply text-gray-300 text-lg text-justify;
}

a {
  @apply text-blue-500 text-lg cursor-pointer underline;
}

ul {
  @apply text-gray-300 text-lg;
}
</style>