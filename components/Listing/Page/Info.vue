<template>
    <div class="px-8 pb-8 flex flex-col justify-between md:max-h-[700px]">
        <h4 class="my-3 md:mt-0">NAME</h4>
        <h3 class="my-3">PRICE ₽</h3>
        <div class="flex flex-row p-2 text-nowrap border border-gray-300 rounded cursor-pointer w-fit my-3 space-x-2">
            <IconsHeartOutline />
            <p>В избранное</p>
        </div>
        <div class="my-3">
            <div class="w-32 flex flex-row items-center justify-around"><img class="size-9 rounded-[50%]" src="/img/user_profile.png"><h5>Продавец</h5></div>
            <div class="mt-3 p-1 border border-gray-500 rounded-md w-44 text-center">Написать продавцу</div>
        </div>
    </div>
</template>
