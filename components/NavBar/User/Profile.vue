<script setup
    lang="ts">
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
    <DropdownMenu>
        <DropdownMenuTrigger>
            <div class="flex flex-row space-x-3">
                <Avatar class="size-6">
                    <AvatarImage src="https://github.com/radix-vue.png" alt="@radix-vue" />
                    <AvatarFallback>CN</AvatarFallback>
                </Avatar>
               <p>{{ userStore.user.username }}</p>
            </div>
        </DropdownMenuTrigger>
        <DropdownMenuContent>
            <DropdownMenuLabel> {{ userStore.user.username }}</DropdownMenuLabel>
            <DropdownMenuSeparator />
            <DropdownMenuItem @click="navigateTo('/user/me')">Профиль</DropdownMenuItem>
            <DropdownMenuItem>Мои объявления</DropdownMenuItem>
            <DropdownMenuItem @click="userStore.userLogout">Выйти</DropdownMenuItem>
        </DropdownMenuContent>
    </DropdownMenu>
</template>