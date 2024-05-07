<script setup lang="ts">

import { Alert, AlertDescription, AlertTitle } from '@/components/ui/alert'

const userStore = useUserStore();

</script>

<template>
    <AuthErrorSignin v-if="userStore.errorAuth" :text="userStore.errorMsg" />
    <NavBarLogo />
    <AuthSigninForm />
</template>