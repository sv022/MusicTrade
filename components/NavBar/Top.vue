<script setup lang="ts">
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuSeparator,
    DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu'

const userStore = useUserStore();

</script>

<template>

<div class="flex h-[60px] w-screen border text-center sticky top-0 z-10 bg-white px-5">
    <ul class="hidden md:flex flex-row items-center basis-1/4 justify-around text-nowrap text-sm space-x-3">
        <li>O нас</li>
        <li>Продавцам</li>
        <li>Покупателям</li>
    </ul>
    <div class="basis-1/4 flex md:hidden items-center">
        <DropdownMenu>
            <DropdownMenuTrigger>
                <iconsBars />
            </DropdownMenuTrigger>
            <DropdownMenuContent>
                <DropdownMenuItem>O нас</DropdownMenuItem>
                <DropdownMenuItem>Продавцам</DropdownMenuItem>
                <DropdownMenuItem>Покупателям</DropdownMenuItem>
            </DropdownMenuContent>
        </DropdownMenu>
    </div>
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
        <div class="flex flex-row space-x-2 md:space-x-10 items-center ml-auto" v-else>
            <!-- <IconsHeartFill @click="navigateTo('/favorites')" /> -->
            <NavBarFavButton />
            <NuxtLink to="/signin"><p class="text-center hidden md:inline">Вход и регистрация</p></NuxtLink>
            <NuxtLink v-if="userStore.isAuth" to="/signin" class="md:hidden"><IconsUserProfile /></NuxtLink>
            <NuxtLink v-else to="/signin" class="md:hidden"><IconsUserLogin /></NuxtLink>    
        </div>
    </div>
</div>    

</template>