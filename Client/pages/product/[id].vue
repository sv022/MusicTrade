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
    targetListing.value = listings.find(l => l.id == route.params.id)
    isPending.value = false;
})

</script>

<template>
    <NavBarTop />
    <NavBarLogo />
    <p v-if="isPending">Загрузка...</p>
    <ListingPageContainer :item="targetListing" v-else />
</template>