<script setup lang="ts">
import { ref } from 'vue'
import { watchOnce } from '@vueuse/core'
import { Carousel, type CarouselApi, CarouselContent, CarouselItem, CarouselNext, CarouselPrevious } from '@/components/ui/carousel'
import { Card, CardContent } from '@/components/ui/card'

const emblaMainApi = ref<CarouselApi>()
const emblaThumbnailApi = ref<CarouselApi>()
const selectedIndex = ref(0)

function onSelect() {
  if (!emblaMainApi.value || !emblaThumbnailApi.value)
    return
  selectedIndex.value = emblaMainApi.value.selectedScrollSnap()
  emblaThumbnailApi.value.scrollTo(emblaMainApi.value.selectedScrollSnap())
}

function onThumbClick(index: number) {
  if (!emblaMainApi.value || !emblaThumbnailApi.value)
    return
  emblaMainApi.value.scrollTo(index)
}

watchOnce(emblaMainApi, (emblaMainApi) => {
  if (!emblaMainApi)
    return

  onSelect()
  emblaMainApi.on('select', onSelect)
  emblaMainApi.on('reInit', onSelect)
})

const props = defineProps<{
  images: string[]
}>();

</script>

<template>
  <div class="grid grid-cols-1 w-[625px] md:w-[800px] md:min-w-[800px] aspect-[4/3]">
    <div class="flex w-full justify-around">
        <Carousel
          class="w-5/6"
          @init-api="(val) => emblaMainApi = val"
        >
          <CarouselContent>
            <CarouselItem v-for="img in images" :key="img">
              <div class="p-1 h-full">
                <Card class="h-full items-center justify-center">
                  <CardContent class="flex items-center justify-center p-2">
                    <img class="listing_photo" :src="`https://raw.githubusercontent.com/sv022/MockDB/main/MusicTrade/img/${img}.png`" alt="">
                  </CardContent>
                </Card>
              </div>
            </CarouselItem>
          </CarouselContent>
          <CarouselPrevious />
          <CarouselNext />
        </Carousel>
    </div>

    <div class="flex w-full justify-around">
        <Carousel
          class="w-3/5"
          @init-api="(val) => emblaThumbnailApi = val"
        >
          <CarouselContent class="flex gap-1 ml-0">
            <CarouselItem v-for="(img, index) in images" :key="img" class="pl-0 basis-1/4 cursor-pointer" @click="onThumbClick(index)">
              <div class="p-1" :class="index === selectedIndex ? '' : 'opacity-50'">
                <Card>
                  <CardContent class="flex aspect-square items-center justify-center p-3">
                    <img class="listing_photo_small" :src="`https://raw.githubusercontent.com/sv022/MockDB/main/MusicTrade/img/${img}.png`" alt="">
                  </CardContent>
                </Card>
              </div>
            </CarouselItem>
          </CarouselContent>
        </Carousel>
    </div>
  </div>
</template>

<style>
.listing_photo {
    width: 650px;
    height: 435px;
    align-content: center;
    border-radius: 5px;
    object-fit: cover;
}
.listing_photo_small {
    width: 75px;
    height: 50px;
    align-content: center;
    border-radius: 10px;
    object-fit: cover;
}
@media (max-width: 768px) {
  .listing_photo {
    width: 500px;
    height: 270px;
  }
  .listing_photo_small {
    width: 70px;
    height: 50px;
    border-radius: 2px;
  }
}
</style>