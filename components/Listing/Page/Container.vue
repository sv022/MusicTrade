<script setup lang="ts">
import type { IListing } from '@/types/listing.interface';
import useUserData from '~/composables/useData';


const { loadListings } = useUserData();

let listings = [];
let targetListing = ref({} as IListing);
let isPending = ref(true);
const route = useRoute();

onMounted( async () => {
    listings = (await loadListings()).data;
    isPending.value = false;
    targetListing.value = listings.find(l => l.id == route.params.id)
})

</script>

<template>

<p v-if="isPending">Загрузка...</p>
<div v-else class="p-5 md:px-32 pt-7">
    <div class="flex flex-col md:flex-row w-[800px] md:w-full">
        <ListingPageGallery :images="targetListing.img" />
        <ListingPageInfo :targetListing="targetListing" />
    </div>
    <ListingPageDescription :targetListing="targetListing"/>
</div>

</template>