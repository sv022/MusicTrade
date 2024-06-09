<script setup>

const query = useRoute().query["query"];
const tag = useRoute().query["tag"];
const category = useRoute().query["category"];

useHead({
    title: `${query || tag || category} - Поиск по запросу | MusicTrade.ru`
})

</script>

<template>
    <NavBarTop />
    <NavBarSearch />
    <div class="p-10 pt-0">
        <ListingSearchContainer :tag="tag" :query="query" :category="category" />
    </div>
</template>

