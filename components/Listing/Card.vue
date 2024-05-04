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
            <!-- heart icon -->
            <svg class="ml-auto mr-3 cursor-pointer" width="30.000000" height="30.000000" viewBox="0 0 33 30" fill="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
              <desc>
                  Created with Pixso.
              </desc>
              <defs/>
              <path d="M16.23 2.48C20.04 -0.95 25.93 -0.83 29.6 2.85C33.27 6.53 33.4 12.39 29.99 16.21L16.22 30L2.46 16.21C-0.95 12.39 -0.82 6.52 2.85 2.85C6.52 -0.83 12.4 -0.95 16.23 2.48L16.23 2.48ZM27.3 5.14C24.87 2.7 20.94 2.6 18.39 4.89L16.23 6.84L14.06 4.89C11.5 2.6 7.58 2.7 5.14 5.14C2.72 7.56 2.6 11.43 4.83 13.99L16.22 25.4L27.62 13.99C29.85 11.43 29.73 7.57 27.3 5.14L27.3 5.14Z" fill="#444444" fill-opacity="1.000000" fill-rule="evenodd"/>
            </svg>
            <!-- <img class="heart_listing"> -->
        </div>
        <h6 class="mt-8 text-xs font-semibold text-gray-400">Location (at xxx)</h6>
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
  margin: 5px;
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

</style>