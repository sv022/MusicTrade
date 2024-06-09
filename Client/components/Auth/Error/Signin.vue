<script setup lang="ts">
import { string } from 'yup';

const props = defineProps<{ text?: string }>();

</script>

<template>

<Alert class="fixed left-2/4 top-16 translate-x-[-50%] w-fit z-10 bg-rose-400 rounded opacity-85">
    <AlertDescription class="text-center text-sm text-nowrap text-cold-white">
    {{ props.text }}
    </AlertDescription>
</Alert>

</template>