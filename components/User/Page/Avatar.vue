<script setup>

const userStore = useUserStore();

</script>

<template>
    <div class="grid grid-cols-1 grid-rows-1">
        <img class="size-40 layer1 rounded-[50%]" :src="`https://raw.githubusercontent.com/sv022/MockDB/main/MusicTrade/img/${userStore.user.id}.png`" alt="">
        <iconsPlusSquare class="layer2 relative top-[140px] left-[140px]" />
    </div>
</template>

<style>
.layer1, .layer2{
  grid-column: 1;
  grid-row: 1;
}
</style>