<script setup lang="ts">
import type { IListing } from '@/types/listing.interface';
import useUserData from '~/composables/useData';

const props = defineProps<{
    item: IListing
}>();

useHead({
    title: `${props.item.title} - Поиск по запросу | MusicTrade.ru`
})

</script>

<template>

<div class="p-5 md:px-32 pt-7">
    <div class="flex flex-col md:flex-row w-[800px] md:w-full">
        <ListingPageGallery :images="props.item.img" />
        <ListingPageInfo :targetListing="props.item" />
    </div>
    <ListingPageDescription :targetListing="props.item"/>
</div>

</template>