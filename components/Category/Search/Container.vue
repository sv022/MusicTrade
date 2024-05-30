<script setup lang="ts">

import type { ICategory } from "~/types/category.interface";

const categories = ref<ICategory[]>([
    { name: "Электрогитары", img: "assets/guitar.png", tag: "electricGuitar" },
    { name: "Классические гитары", img: "assets/classicguitar.png", tag: "classicGuitar" },
    { name: "Акустические гитары", img: "assets/acousticguitar.png", tag: "acousticGuitar" },
    { name: "Гитарное усиление", img: "assets/amp.png", tag: "amplifier" },
    { name: "Педали эффектов", img: "assets/pedals.png", tag: "guitarPedal" },
]);

</script>

<template>

<div class="p-10 pt-0">
    <h2 class="p-10 pl-0 text-3xl">Искать в категории</h2>
    <div class="flex flex-wrap">
        <CategorySearchItem v-for="c in categories" :key="c.name" :item="c" />
    </div>
</div>

</template>