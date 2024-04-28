<script setup>

const userCity = useCookie("userCity")
userCity.value = userCity.value || "Москва"

</script>

<template>
    <NavBarTop />
    <NavBarSearch />
    <ListingContainer />
</template>

<style scoped>



</style>
