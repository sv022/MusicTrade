<script setup lang="ts">

const userStore = useUserStore();

</script>

<template>

<div class="flex h-[60px] w-screen border text-center sticky top-0 z-10 bg-white">
    <ul class="basis-1/4 flex flex-row items-center justify-around text-nowrap text-sm ml-3">
        <li>O нас</li>
        <li>Продавцам</li>
        <li>Покупателям</li>
    </ul>
    <div class="basis-1/4 flex flex-row-reverse items-center text-center space-x-10"></div>
    <div class="basis-1/2 flex flex-row items-center text-nowrap">
        <div v-if="userStore.isAuth" class="flex flex-row items-center space-x-16 ml-auto mr-16">
            <div class="flex flex-row text-nowrap text-sm font-thin items-center space-x-10">
                <button class=" min-w-36 h-8 bg-blue-gray rounded">Разместить</button>
                <p>Мои объявления</p>
            </div>
            <div class="flex flex-row space-x-10">
                <NavBarFavButton />
                <NavBarUserProfile />            
            </div>
        </div>
        <div class="flex flex-row space-x-5 items-center ml-auto mr-16" v-else>
            <!-- <IconsHeartFill @click="navigateTo('/favorites')" /> -->
            <NavBarFavButton />
            <NuxtLink to="/signin"><p class="text-center">Вход и регистрация</p></NuxtLink>
        </div>
    </div>
</div>    

</template>