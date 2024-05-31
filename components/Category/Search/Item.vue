<script setup lang="ts">

import type { ICategory } from "~/types/category.interface";

const props = defineProps<{
    item: ICategory
}>();

</script>

<template>

    <div @click="navigateTo(`search?tag=${item.tag}`)" class="flex flex-col min-w-40 max-w-52 bg-slate-50 p-2 m-1 text-nowrap rounded cursor-pointer">
        <p class="text-xs font-semibold text-gray-600 mb-3">{{ item.name }}</p>
        <img class="max-w-28 max-h-20 ml-auto mt-auto" :src="`img/${item.img}`" :alt="`Категория ${item.name}`">
    </div>

</template>

<style scoped>
div:hover {
    box-shadow: 3px 3px rgba(241 245 249);
    box-shadow: 3px 3px 6px rgba(241 245 249), -3px -3px 6px rgba(241 245 249), -3px 3px 6px rgba(241 245 249), 3px -3px 6px rgba(241 245 249);
}

</style>