<script setup>

const userCity = useCookie("userCity")
userCity.value = userCity.value || "Москва"

</script>

<template>
    <NavBarTop />
    <NavBarSearch />
    <div class="p-10 pt-0">
        <CategorySearchContainer />
        <ListingContainer />
    </div>
</template>

<style scoped>



</style>
