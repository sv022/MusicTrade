<script setup lang="ts">

const userStore = useUserStore();

</script>

<template>
    <div>
        <div class="flex flex-row text-3xl p-3 items-center w-5/6 justify-between">
            <p>{{ userStore.user.username }}</p>
            <iconsPen />
        </div>
        <div class="flex flex-row text-3xl p-3 items-center w-5/6 justify-between">
            <p>{{ userStore.user.email }}</p>
            <iconsPen />
        </div>
        <div class="flex flex-row text-3xl p-3 items-center w-5/6 justify-between">
            <p>{{ userStore.user.phone }}</p>
            <iconsPen />
        </div>
    </div>
</template>