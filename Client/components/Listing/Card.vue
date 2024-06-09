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
      <img :src="`https://raw.githubusercontent.com/sv022/MockDB/main/MusicTrade/img/${listing.img[0]}.png`" class="listing_photo">
    </div>
    <div class="flex flex-col w-[270px] h-[150px]">
      <h5 class="line-clamp-2 text-sm min-h-[50px]">{{ listing.title }}</h5>
      <div class="h-8 flex items-center">
        <h4 class="font-semibold text-gray-800">{{ listing.price }} ₽</h4>
        <div @click.stop="favStore.toggleFav(listing)" class="flex justify-center items-center ml-auto rounded-[50%] size-8 hover:bg-slate-100">
          <IconsHeartFill v-if="favStore.listings.some(l => l.id == listing.id)"/>
          <IconsHeartBlack v-else />
        </div>
      </div>
      <h6 class="mt-auto text-xs font-semibold text-gray-400">{{ listing.adress }}</h6>
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
    cursor: pointer;
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