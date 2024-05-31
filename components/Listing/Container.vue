<script setup lang="ts">
import useUserData from '~/composables/useData';
const { loadListings } = useUserData();

let listings = ref([])
let isPending = ref(true);

onMounted( async () => {
    listings.value = (await loadListings()).data;
    isPending.value = false
})

</script>

<template>
    <div>
        <h2 class="p-10 text-3xl">Интересные объявления</h2>
        <div class="flex flex-wrap px-10">
            <ListingCard v-for="listing in listings" :key="listing.id" :listing="listing"/>
            <p v-if="isPending">Загрузка...</p>
        </div>
    </div>
</template>
