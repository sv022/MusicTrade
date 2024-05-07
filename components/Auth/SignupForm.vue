<script setup>
import { useForm } from 'vee-validate';
import * as yup from 'yup';

const userStore = useUserStore();

const { errors, handleSubmit, defineField } = useForm({
  validationSchema: yup.object({
    username: yup.string().required("*Обязательное поле"),
    email: yup.string().email("*Некорректный адрес email").required("*Обязательное поле"),
    password: yup.string().min(8, "Пароль должен содержать как минимум 8 символов").required("*Обязательное поле"),
  }),
});

const [username, usernameAttrs] = defineField('username');
const [email, emailAttrs] = defineField('email');
const [password, passwordAttrs] = defineField('password');

const onSubmit = handleSubmit(userInfo => {
    userStore.userSingUp(userInfo);
});

</script>


<template>

<div class="bg-gray-100 flex justify-center items-center h-svh mt-[-120px]">
    <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4 w-96" @submit="onSubmit">
        <h2 class="text-2xl font-bold mb-6">Регистрация</h2>
        <div class="mb-4">
            <label class="block text-gray-700 text-sm font-bold mb-2" for="username">Имя пользователя:</label>
            <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" v-model="username" v-bind="usernameAttrs" placeholder="Имя пользователя">
            <div class="text-xs text-red-hover">{{ errors.username }}</div>
        </div>
        <div class="mb-4">
            <label class="block text-gray-700 text-sm font-bold mb-2" for="email">Email:</label>
            <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" v-model="email" v-bind="emailAttrs" type="email" placeholder="Email">
            <div class="text-xs text-red-hover">{{ errors.email }}</div>
        </div>
        <div class="mb-4">
            <label class="block text-gray-700 text-sm font-bold mb-2" for="password">Пароль:</label>
            <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" v-model="password" v-bind="passwordAttrs" type="password" placeholder="Пароль">
            <div class="text-xs text-red-hover">{{ errors.password }}</div>
        </div>  
        <div class="flex items-center justify-between">
            <button class="bg-lime-green-100 hover:bg-lime-green-200 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline cursor-pointer">Зарегистрироваться</button>
            <NuxtLink class="inline-block align-baseline font-bold text-sm text-red hover:text-red-hover" to='/signin'>Отмена</NuxtLink>
        </div>
    </form>
</div> 
    
</template>