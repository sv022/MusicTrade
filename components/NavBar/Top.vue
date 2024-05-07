<script setup lang="ts">

const userStore = useUserStore();

</script>

<template>

<div class="flex h-[60px] w-screen border text-center">
    <ul class="basis-1/4 flex flex-row items-center justify-around text-nowrap text-sm ml-3">
        <li>O нас</li>
        <li>Продавцам</li>
        <li>Покупателям</li>
    </ul>
    <div class="basis-1/2 flex flex-row-reverse items-center text-center space-x-10">
        <div v-if="userStore.isAuth" class="basis-1/4 min-w-40 ml-3">
        <button class=" min-w-36 h-8 bg-blue-gray rounded">Разместить</button>
        </div>
        <ul v-if="userStore.isAuth" class='basis-1/3 flex flex-row justify-between text-nowrap space-x-0.5 text-sm'>
        <li>Избранное</li>
        <li>Мои объявления</li>
        </ul>
    </div>
    <div class="basis-1/4 flex flex-row items-center justify-around text-nowrap">
        <div v-if="userStore.isAuth" class="flex flex-row space-x-3">
            <Avatar class="size-6">
                <AvatarImage src="https://github.com/radix-vue.png" alt="@radix-vue" />
                <AvatarFallback>CN</AvatarFallback>
            </Avatar>
            <p @click="userStore.userLogout" class="cursor-pointer">{{ userStore.user.username }}</p>
        </div>
        <NuxtLink v-else to="/signin"><p>Вход и регистрация</p></NuxtLink>
    </div>
</div>    

</template>