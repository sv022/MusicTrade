<script setup lang="ts">
import type { IListing } from '@/types/listing.interface';

const favStore = useFavStore();

const props = defineProps<{
  listing: IListing
}>();

function navigate() {
  return navigateTo(`product/${props.listing.id}`)
}

</script>

<template>

  <div class="listing space-y-2" v-on:click="navigate()">
    <div>
      <img src="/img/listing_placeholder_2.jpg" class="listing_photo">
    </div>
    <div class="w-[270px]">
      <h5>{{ listing.title }}</h5>
      <div class="h-8 flex">
        <h4 class="font-semibold text-gray-800">{{ listing.price }} ₽</h4>
        <!-- heart icon -->
        <IconsHeartFill v-if="favStore.listings.some(l => l.id == listing.id)"
          @click.stop="favStore.toggleFav(listing)" class="ml-auto" />
        <IconsHeartBlack v-else @click.stop="favStore.toggleFav(listing)" class="ml-auto" />
        <!-- <img class="heart_listing"> -->
      </div>
      <h6 class="mt-6 text-xs font-semibold text-gray-400">Location (at xxx)</h6>
    </div>
  </div>

</template>

<style scoped>

  .listing {
    height: 350px;
    width: 300px;
    padding: 10px;
    display: flex;
    flex-direction: column;
    align-items: center;
    /* border: 1px solid #f3f3f3; */
    border-radius: 10px;
    margin: 8px;
    color: #232122;
  }

  .listing:hover {
    box-shadow: 3px 3px rgb(201, 208, 209);
    box-shadow: 3px 3px 6px rgb(238, 244, 245), -3px -3px 6px rgb(238, 244, 245), -3px 3px 6px rgb(238, 244, 245), 3px -3px 6px rgb(238, 244, 245);
  }

  .listing_photo {
    width: 270px;
    height: 200px;
    align-content: center;
    border-radius: 10px;
    object-fit: cover;
  }

</style>