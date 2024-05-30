<script setup lang="ts">
import type { IListing } from '@/types/listing.interface';

const listing = ref({} as IListing);

const props = defineProps<{
  targetListing: IListing
}>();

listing.value = props.targetListing;

</script>

<template>
    <div class="px-3">
        <h3 class="text-3xl p-4">Описание</h3>
        <p class="w-full md:w-5/6">{{ listing.description }}</p>
    </div> 
</template>
