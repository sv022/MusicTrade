<script setup>

let l = [{"id": 1, "name": "1", "price": 10000}, {"id": 2, "name": "2", "price": 20000}, {"id": 3, "name": "3", "price": 30000}, 
{"id": 4, "name": "4", "price": 40000}, {"id": 5, "name": "5", "price": 50000}, {"id": 6, "name": "6", "price": 60000}, 
{"id": 7, "name": "7", "price": 70000}, {"id": 8, "name": "8", "price": 80000}, {"id": 9, "name": "9", "price": 90000}, ]

let listings = ref(l)


</script>

<template>
    <div class="flex flex-wrap p-10">
        <ListingCard v-for="listing in listings" :key="listing.id" :item="listing"/>
    </div>
</template>