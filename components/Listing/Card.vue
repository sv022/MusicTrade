<script setup>

defineProps(["item"])

</script>

<template>

<div class="listing">
    <div style="text-align: center; width: 100%;">
        <img src="/img/listing_placeholder_2.jpg" class="listing_photo">
    </div>
    <div>
        <h5>{{ item.name }}</h5>
        <div class="h-8 flex">
            <h4>{{ item.price }} ₽</h4>
            <img class="heart_listing">
        </div>
        <h6>LOCATION</h6>
    </div>
</div>        
    
</template>

<style scoped>

.listing {
  height: 350px;
  width: 300px;
  padding: 0.5%;
  /* border: 1px solid #f3f3f3; */
  border-radius: 10px;
  margin: 3px;
  color: #232122;
}
.listing:hover {
  box-shadow: 3px 3px rgb(201, 208, 209);
  box-shadow: 3px 3px 6px rgb(238, 244, 245), -3px -3px 6px rgb(238, 244, 245), -3px 3px 6px rgb(238, 244, 245), 3px -3px 6px rgb(238, 244, 245);
}
.listing_photo {
  width: 270px;
  height: 200px;
  align-content: center;
  border-radius: 10px;
  object-fit: cover;
}
.heart_listing {
  content: url("img/heart_outline_black.png");
  height: 25px; 
  padding: 2%;
  margin-left: auto;
}

</style>