<script setup>

const favStore = useFavStore();

</script>

<template>

<div>
    <h2 class="p-10 pl-0 text-3xl">Избранные объявления</h2>
    <div class="flex flex-row space-x-5">
        <div class="flex flex-col">
            <FavoritesCard v-for="listing in favStore.listings" :key="listing.id" :listing="listing" />
        </div>
        <FilterContainer />
    </div>
</div>

</template>