<script setup>
const { loadListings } = useData();

let listings = ref([])
let fetchError = ref(false);
let isPending = ref(true);

onMounted( async () => {
    listings.value = (await loadListings()).data;
    console.log(listings.value)
    isPending.value = false
})

</script>

<template>
    <h2 class="p-10 text-3xl">Интересные объявления</h2>
    <div class="flex flex-wrap px-14">
        <ListingCard v-for="listing in listings" :key="listing.id" :listing="listing"/>
        <p v-if="fetchError">Что-то пошло не так</p>
        <p v-if="isPending">Загрузка...</p>
    </div>
</template>
