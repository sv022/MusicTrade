<template>

<div class="flex flex-row items-center w-full h-32 border-b border-soft-gray" id="main">
    <div class="w-fit max-w-80 mx-8">
        <NuxtLink to="/">
            <picture>
                <source media="(min-width: 1020px)" srcset="\img\guitar_logo.png">
                <img src="/img/guitar_logo_small.png">
            </picture>
        </NuxtLink>
    </div>
    <div class="flex flex-row justify-between w-1/2 h-10 p-2 items-center border border-gray-500 rounded">
        <input type="text" placeholder="Поиск по объявлениям" id="searchbar">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6">
            <path stroke-linecap="round" stroke-linejoin="round" d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z" />
        </svg>
    </div>
</div>  

</template>

<style scoped>
input {
    margin-left: 5px;
    width: 93%; 
    border: none;
    outline: none;
    color: #2f4858;
    border-radius: 5px;
}

.topmenu {
    display: flex;
    align-items: center;
    width: 100%;
    height: 60px;
    border-bottom: 1px solid #DDDEDE;
}

.topleftmenu {
    width: 20%;
    margin-left: 3dvw;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

.topleftmenu li {
    list-style: none;
    text-wrap: nowrap;
    padding: 1vw;
}

.userbuttons {
    margin-left: auto;
    margin-right: 5%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}

.userbuttons li {
    list-style: none;
    text-wrap: nowrap;
    padding: 0.5vw;
}

.userprofile {
    display: flex;
    align-items: center;
    height: 30px;
    margin-right: 3%;
    padding-left: 3%;
    border-left: 1px solid #DDDEDE;
}
</style>