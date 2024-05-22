<script setup lang="ts">
import type { IListing } from '@/types/listing.interface';

let l = [
    {
        id: 1,
        owner: {
            id: 11,
            username: "svo",
            email: "test@mail.com",
            password: "",
            city: "msk",
            phone: "...",
            signupdate: "never"
        },
        title: "listing 1",
        price: 10000,
        category: "elg",
        isExchangable: false,
        description: "description",
        adress: "location at xxx",
        tags: "tags",
        publishDate: "22.05.2024",
        img: []
    },
    {
        id: 2,
        owner: {
            id: 11,
            username: "svo",
            email: "test@mail.com",
            password: "",
            city: "msk",
            phone: "...",
            signupdate: "never"
        },
        title: "listing 2",
        price: 20000,
        category: "elg",
        isExchangable: false,
        description: "description",
        adress: "location at xxx",
        tags: "tags",
        publishDate: "22.05.2024",
        img: []
    },
    {
        id: 3,
        owner: {
            id: 11,
            username: "svo",
            email: "test@mail.com",
            password: "",
            city: "msk",
            phone: "...",
            signupdate: "never"
        },
        title: "listing 3",
        price: 30000,
        category: "elg",
        isExchangable: false,
        description: "description",
        adress: "location at xxx",
        tags: "tags",
        publishDate: "22.05.2024",
        img: []
    }
]

let listings = ref<IListing[]>(l)

</script>

<template>
    <h2 class="p-10 text-3xl">Интересные объявления</h2>
    <div class="flex flex-wrap px-14">
        <ListingCard v-for="listing in listings" :key="listing.id" :listing="listing"/>
    </div>
</template>
