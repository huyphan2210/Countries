<script setup lang="ts">
import { useStore } from "vuex";
import { ACTION_TYPES } from "./store/CountryStore";

const store = useStore();
store.dispatch(ACTION_TYPES.getCountries);
</script>

<template>
  <header></header>
  <main></main>
  <footer></footer>
</template>

<style scoped></style>
