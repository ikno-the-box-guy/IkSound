<script setup>
import {ref} from "vue";
import {useRouter} from "vue-router";

const props = defineProps({
  isSfx: Boolean
})

const searchTerm = ref('')
const router = useRouter()

const search = () => {
  router.push({
    path: '/search',
    query: {
      term: searchTerm.value,
      sfx: props.isSfx
    }
  })
}
</script>

<template>
  <form @submit.prevent="search" class="mt-2">
    <input type="text" v-model="searchTerm" id="searchbar" placeholder="Search"/>
  </form>
</template>

<style scoped>
#searchbar {
  @apply block w-full px-3 py-1.5 appearance-none bg-transparent rounded-md border !outline-0;

  border-color: #495057;
  transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}

#searchbar:focus {
  border-color: #86b7fe;
  box-shadow: 0 0 0 .25rem rgba(13, 110, 253, .25);
}
</style>