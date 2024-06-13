<script lang="ts" setup>
import type { Country } from "@/swagger/api";
import { defineProps } from "vue";

const { country } = defineProps<{ country: Country }>();
</script>

<template>
  <button type="button" class="country-card">
    <div class="country-card__header">
      <img :src="country.flag" loading="lazy" :alt="country.name" />
    </div>
    <div class="country-card__body">
      <h2>{{ country.name }}</h2>
      <div class="country-card__body__info">
        <p><span>Population: </span> {{ country.population }}</p>
        <p><span>Region: </span> {{ country.region }}</p>
        <p><span>Capital: </span> {{ country.capital }}</p>
      </div>
    </div>
  </button>
</template>

<style lang="scss" scoped>
.country-card {
  background-color: var(--element-bg);
  border-radius: var(--border-radius);
  padding: 0;
  border: none;
  box-shadow: 0 0 1rem 0.1rem rgba(0, 0, 0, 0.1);

  &__header {
    img {
      width: 100%;
      border-radius: var(--border-radius) var(--border-radius) 0 0;
      aspect-ratio: 1.5;
    }
  }

  &__body {
    padding: 1.5rem;
    text-align: left;

    h2 {
      margin-top: 0;
    }

    &__info {
      p {
        margin-top: 0;

        span {
          font-weight: 700;
        }
      }
    }
  }
}
</style>
