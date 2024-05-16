<script setup
    lang="ts">

        import type { ICategory } from "~/types/category.interface";

        const props = defineProps<{
            item: ICategory
        }>();

</script>

<template>

    <div class="flex flex-col min-w-40 max-w-52 bg-slate-50 p-2 m-1 text-nowrap rounded">
        <p class="text-xs font-semibold text-gray-600 mb-3">{{ item.name }}</p>
        <img class="max-w-28 max-h-20 ml-auto mt-auto" :src="`img/${item.img}`" :alt="`Категория ${item.name}`">
    </div>

</template>

<style scoped>

</style>