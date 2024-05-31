<script setup>

const favStore = useFavStore();

</script>

<template>

<div>
    <h2 class="p-10 pl-0 text-3xl">Избранные объявления</h2>
    <div class="flex flex-row space-x-5">
        <div class="flex flex-col w-[1080px]">
            <FavoritesCard v-for="listing in favStore.listings" :key="listing.id" :listing="listing" />
            <div v-if="favStore.listings.length === 0" class="w-5/6 space-y-5">
                <p class="font-semibold">Сохраняйте объявления</p>
                <p>Если вы нашли что-то интересное, нажмите «Добавить в избранное» в объявлении или на сердечко в результатах поиска.</p>
                <img class="w-[500px] ml-[250px]" :src="`img/assets/favempty.png`">
            </div>
        </div>
        <FilterContainer />
    </div>
</div>

</template>