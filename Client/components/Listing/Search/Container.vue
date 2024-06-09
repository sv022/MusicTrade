<script setup lang="ts">
import useUserData from '~/composables/useData';
const { loadListings } = useUserData();

const props = defineProps<{
    query: string,
    tag: string,
    category: string
}>();

let listings = ref([]);
let isPending = ref(true);

const query = props.query;
const tag = props.tag;
const category = props.category;

onMounted( async () => {
    listings.value = (await loadListings()).data;
    if (tag) {
        listings.value = listings.value.filter(l => l.tags.lastIndexOf(tag) !== -1);
    } else if (category) {
        listings.value = listings.value.filter(l => l.category == category);
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
