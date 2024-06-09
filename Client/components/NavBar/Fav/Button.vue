<script setup lang="ts">

const favStore = useFavStore();

</script>

<template>
    <div class="grid grid-cols-1 grid-rows-1">
        <IconsHeartFill class="layer1" @click="navigateTo('/favorites')" />
        <div v-if="favStore.favCount > 0" class="rounded-[50%] bg-red text-[9px] text-cold-white size-[13px] relative top-[11px] left-3 m-0 layer2"> {{ Math.min(favStore.favCount, 99) }}</div>
    </div>
</template>

<style>
.layer1, .layer2{
  grid-column: 1;
  grid-row: 1;
}
</style>