<script setup lang="ts">
import { useStore } from "vuex";

const store = useStore();
store.dispatch("getCountries");
</script>

<template>
  <header></header>
  <main></main>
  <footer></footer>
</template>

<style scoped></style>
