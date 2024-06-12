<script lang="ts" setup>
import type { Country } from "@/swagger/api";
import { defineProps } from "vue";

const { country } = defineProps<{ country: Country }>();
</script>

<template>
  <div class="country-card">
    <div class="country-card__header">
      <img :src="country.flag" loading="lazy" :alt="country.name" />
    </div>
    <div class="country-card__body">
      {{ country.name }}
    </div>
  </div>
</template>

<style lang="scss" scoped>
.country-card {
  background-color: var(--element-bg);
  border-radius: var(--border-radius);

  &__header {
    img {
      width: 100%;
      border-radius: var(--border-radius) var(--border-radius) 0 0;
      aspect-ratio: 1.5;
    }
  }

  &__body {
    padding: 1.5rem;
  }
}
</style>
