<script setup lang="ts">
useHead({
    title: `Вход в аккаунт | MusicTrade.ru`
})

import { Alert, AlertDescription, AlertTitle } from '@/components/ui/alert'

const userStore = useUserStore();

</script>

<template>
    <AuthErrorSignin v-if="userStore.errorAuth" :text="userStore.errorMsg" />
    <NavBarLogo />
    <AuthSigninForm />
</template>