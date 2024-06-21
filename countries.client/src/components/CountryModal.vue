<script setup lang="ts">
import { MUTATION_TYPES, type CountryState } from "@/store/CountryStore";
import { Store, useStore } from "vuex";

const { state, commit }: Store<CountryState> = useStore();
</script>

<template>
  <section
    :class="state.currentCountry ? 'country-modal opened' : 'country-modal'"
  >
    <button
      class="country-modal__back-button"
      type="button"
      @click="() => commit(MUTATION_TYPES.setCurrentCountry)"
    >
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512">
        <path
          fill="var(--text-color)"
          d="M9.4 233.4c-12.5 12.5-12.5 32.8 0 45.3l160 160c12.5 12.5 32.8 12.5 45.3 0s12.5-32.8 0-45.3L109.2 288 416 288c17.7 0 32-14.3 32-32s-14.3-32-32-32l-306.7 0L214.6 118.6c12.5-12.5 12.5-32.8 0-45.3s-32.8-12.5-45.3 0l-160 160z"
        />
      </svg>
      <span>Back</span>
    </button>
    <div class="country-modal__info">
      <img
        :src="state.currentCountry?.flag"
        loading="lazy"
        :alt="state.currentCountry?.name"
        :title="state.currentCountry?.name"
      />
      <div class="country-modal__info__text">
        <h3>{{ state.currentCountry?.name }}</h3>
        <div class="country-modal__info__text__details">
          <div class="country-modal__info__text__details__1">
            <p>
              <span>Native Name: </span>
              <span>{{ state.currentCountry?.nativeName }}</span>
            </p>
            <p>
              <span>Population: </span>
              <span>{{ state.currentCountry?.population }}</span>
            </p>
            <p>
              <span>Region: </span>
              <span>{{ state.currentCountry?.region }}</span>
            </p>
            <p>
              <span>Sub Region: </span>
              <span>{{ state.currentCountry?.subRegion }}</span>
            </p>
            <p v-if="state.currentCountry?.capital">
              <span>Capital: </span>
              <span>{{ state.currentCountry?.capital }}</span>
            </p>
          </div>
          <div class="country-modal__info__text__details__2">
            <p>
              <span
                v-if="
                  state.currentCountry &&
                  state.currentCountry?.topLevelDomain.length > 1
                "
                >Top Level Domains:
              </span>
              <span v-else>Top Level Domain: </span>
              <span>{{ state.currentCountry?.topLevelDomain.join(", ") }}</span>
            </p>
            <p v-if="state.currentCountry?.currencies">
              <span
                v-if="
                  state.currentCountry &&
                  state.currentCountry?.currencies.length > 1
                "
                >Currencies:
              </span>
              <span v-else>Currency: </span>
              <span>{{
                state.currentCountry?.currencies
                  .map((currency) => currency.name)
                  .join(", ")
              }}</span>
            </p>
            <p>
              <span
                v-if="
                  state.currentCountry &&
                  state.currentCountry?.languages.length > 1
                "
                >Languages:
              </span>
              <span v-else>Language: </span>
              <span>{{
                state.currentCountry?.languages
                  .map((language) => language.name)
                  .join(", ")
              }}</span>
            </p>
          </div>
        </div>
        <div
          v-if="state.currentCountry?.borders"
          class="country-modal__info__text__borders"
        >
          <h3>Border Countries:</h3>
          <div class="country-modal__info__text__borders__countries">
            <button
              class="country-modal__info__text__borders__countries__name"
              v-for="(border, index) in state.currentCountry?.borders"
              :key="index"
              type="button"
            >
              {{ border }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style lang="scss">
.country-modal {
  position: fixed;
  top: 100vh;
  left: 50%;
  transform: translate(-50%);
  width: calc(100vw - 3rem);
  max-width: 117rem;
  height: calc(100vh - 8rem);
  background-color: var(--main-bg);
  padding: 1.5rem;
  overflow-y: auto;

  &.opened {
    top: 5rem;
  }

  &__back-button {
    padding-inline: 1.5rem;
    padding-block: 0.5rem;
    border: none;
    box-shadow: 0 0 1rem 0.1rem rgba(0, 0, 0, 0.1);
    color: var(--text-color);
    background-color: var(--element-bg);
    display: flex;
    gap: 0.5rem;
    align-items: center;

    svg {
      width: 0.8rem;
    }
  }

  &__info {
    margin-top: 3rem;
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    img {
      width: 100%;
    }

    &__text {
      &__details {
        display: flex;
        flex-wrap: wrap;
        gap: 3rem;
        p {
          span:first-child {
            font-weight: 700;
          }
        }
        margin-bottom: 3rem;
      }

      &__borders {
        display: flex;
        align-items: center;
        flex-wrap: wrap;
        gap: 1rem;

        &__countries {
          display: flex;
          flex-wrap: wrap;
          gap: 0.5rem;

          button {
            border: none;
            padding-inline: 1.5rem;
            background-color: var(--element-bg);
            box-shadow: 0 0 1rem 0.1rem rgba(0, 0, 0, 0.1);
          }
        }
      }
    }
  }
}

@media screen and (min-width: 768px) {
  .country-modal {
    &__info {
      display: grid;
      grid-template-columns: repeat(2, 45%);
      gap: 10%;
    }
  }
}

@media screen and (min-width: 1024px) {
  .country-modal {
    padding-inline: 5rem;
    width: calc(100vw - 10rem);
  }
}
</style>
