<script setup>
import useUserData from '~/composables/useData';
const { loadListings } = useUserData();

let listings = ref([]);
let isPending = ref(true);

const query = useRoute().query["query"];
const tag = useRoute().query["tag"];

onMounted( async () => {
    listings.value = (await loadListings()).data;
    if (tag) {
        listings.value = listings.value.filter(l => l.tags.lastIndexOf(tag) !== -1);
    } else {
        listings.value = listings.value.filter(l => l.title.toLocaleLowerCase().lastIndexOf(query.toLocaleLowerCase()) !== -1);
    }
    isPending.value = false
})

</script>

<template>
    <div>
        <h2 class="p-10 text-3xl">Результаты поиска по запросу {{ `${query || ""}` }}</h2>
        <div class="flex flex-wrap px-14">
            <ListingCard v-for="listing in listings" :key="listing.id" :listing="listing"/>
            <p v-if="isPending">Загрузка...</p>
        </div>
    </div>
</template>
