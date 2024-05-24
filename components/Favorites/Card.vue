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

<div class="listing flex flex-row m-2 items-center justify-around rounded-md" v-on:click="navigate()">
    <div class="w-[290px] min-w-[290px] mx-5">
      <img src="/img/listing_placeholder_2.jpg" class="listing_photo">
    </div>
    <div class="basis-3/6 h-[215px] flex flex-col">
      <div class="space-y-5">
        <h5>{{ listing.title }}</h5>
        <h4 class="font-semibold text-gray-800">{{ listing.price }} ₽</h4>
      </div>
      <div>
      </div>
      <h6 class="mt-auto text-xs font-semibold text-gray-400">Location (at xxx)</h6>
    </div>
    <div class="basis-1/6 flex justify-around h-[215px]">
      <!-- heart icon -->
      <IconsHeartFill v-if="favStore.listings.some(l => l.id == listing.id)"
        @click.stop="favStore.toggleFav(listing)" />
      <IconsHeartBlack v-else @click.stop="favStore.toggleFav(listing)" />
      <!-- <img class="heart_listing"> -->
    </div>
</div>

</template>


<style scoped>
.listing {
    width: 50dvw;
    height: 300px;
    min-width: 550px;
}
.listing:hover {
    box-shadow: 3px 3px rgb(201, 208, 209);
    box-shadow: 3px 3px 6px rgb(238, 244, 245), -3px -3px 6px rgb(238, 244, 245), -3px 3px 6px rgb(238, 244, 245), 3px -3px 6px rgb(238, 244, 245);
}

.listing_photo {
    width: 290px;
    height: 215px;
    align-content: center;
    border-radius: 10px;
    object-fit: cover;
}
</style>