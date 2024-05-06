<script setup>

import { useForm } from 'vee-validate';
import * as yup from 'yup';

const userStore = useUserStore();

const { errors, handleSubmit, defineField } = useForm({
  validationSchema: yup.object({
    username: yup.string(),
    password: yup.string()
  }),
});

const [username, usernameAttrs] = defineField('username');
const [password, passwordAttrs] = defineField('password');

const onSubmit = handleSubmit(userInfo => {
    userStore.userLogin(userInfo);
});

</script>

<template>

<div class="bg-gray-100 flex justify-center items-center h-svh mt-[-120px]">
    <div class="w-full max-w-md">
        <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4" @submit="onSubmit">
            <h2 class="text-2xl font-bold mb-6">Вход в аккаунт</h2>
            <div class="mb-4">
                <label class="block text-gray-700 text-sm font-bold mb-2" for="username">Имя пользователя:</label>
                <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" v-model="username" v-bind="usernameAttrs" placeholder="Имя пользователя">
            </div>
            <div class="mb-6">
                <label class="block text-gray-700 text-sm font-bold mb-2" for="password">Пароль:</label>
                <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" v-model="password" v-bind="passwordAttrs" type="password" placeholder="Пароль" required>
            </div>
            <div class="flex items-center justify-between">
                <button class="bg-lime-green-100 hover:bg-lime-green-200 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline cursor-pointer">Войти</button>
                <NuxtLink class="inline-block align-baseline font-bold text-sm text-lime-green-300 hover:text-lime-green-400" to='/signup'>Регистрация</NuxtLink>
            </div>
        </form>
    </div>
</div>

</template>