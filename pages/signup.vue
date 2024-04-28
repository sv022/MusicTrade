<template>
    <NavBarLogo />
    <div class="bg-gray-100 flex justify-center items-center h-svh mt-[-120px]">
        <form class="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4 w-96" action="#" method="post">
            <h2 class="text-2xl font-bold mb-6">Регистрация</h2>
            <div class="mb-4">
                <label class="block text-gray-700 text-sm font-bold mb-2" for="username">Имя пользователя:</label>
                <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 
                leading-tight focus:outline-none focus:shadow-outline" id="username" name="username" type="text" 
                placeholder="Имя пользователя" required>
            </div>
            <div class="mb-4">
                <label class="block text-gray-700 text-sm font-bold mb-2" for="email">Email:</label>
                <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight 
                focus:outline-none focus:shadow-outline" id="email" name="email" type="email" 
                placeholder="Email" required>
            </div>
            <div class="mb-4">
                <label class="block text-gray-700 text-sm font-bold mb-2" for="password">Пароль:</label>
                <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 
                leading-tight focus:outline-none focus:shadow-outline" id="password" name="password" 
                type="password" placeholder="Пароль" required>
            </div>
            <div class="mb-6">
                <label class="block text-gray-700 text-sm font-bold mb-2" for="password">Повторите пароль:</label>
                <input class="appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none 
                focus:shadow-outline" id="password" name="password" type="password" placeholder="Повторите пароль" required>
            </div>
            <div class="flex items-center justify-between">
                <input class="bg-lime-green-100 hover:bg-lime-green-200 text-white font-bold 
                py-2 px-4 rounded focus:outline-none focus:shadow-outline cursor-pointer" type="submit" 
                value="Зарегистрироваться">
                <NuxtLink class="inline-block align-baseline font-bold text-sm text-red hover:text-red-hover" to='/signin'>Отмена</NuxtLink>
            </div>
        </form>
    </div>
    </template>
    <style scoped>
    .navbar {
        z-index: 10;
        display: flex;
        width: 100%;
        height: 120px;
        align-items : center;
        border-bottom: 1px solid #DDDEDE;
    }
    </style>