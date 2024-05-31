<script setup>
useHead({
    title: "MusicTrade - Продажа и обмен музыкального оборудования"
})

const userCity = useCookie("userCity")
userCity.value = userCity.value || "Москва"

</script>

<template>
    <NavBarTop />
    <NavBarSearch />
    <div class="md:p-10 pt-0">
        <CategorySearchContainer />
        <ListingContainer />
    </div>
</template>

<style scoped>



</style>
