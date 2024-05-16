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
                <svg width="35.000000" height="35.000000" viewBox="0 0 40 40" fill="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                    <path id="矢量 118" d="M20 35.58L17.58 33.38C9 25.6 3.33 20.46 3.33 14.16C3.33 9.03 7.36 5 12.5 5C15.39 5 18.18 6.35 20 8.48C21.81 6.35 24.59 5 27.5 5C32.63 5 36.66 9.03 36.66 14.16C36.66 20.46 31 25.6 22.41 33.4L20 35.58Z" fill="#D58C58" fill-opacity="1.000000" fill-rule="evenodd"/>
                </svg>
                <NavBarUserProfile />            
            </div>
        </div>
        <div class="ml-auto mr-16" v-else>
            <NuxtLink to="/signin"><p>Вход и регистрация</p></NuxtLink>
        </div>
    </div>
</div>    

</template>