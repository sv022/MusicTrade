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
</script>

<template>
  <div class="grid grid-cols-1 w-[426px] md:w-[800px] aspect-[4/3]">
    <div class="flex w-full justify-around">
        <Carousel
          class="w-5/6"
          @init-api="(val) => emblaMainApi = val"
        >
          <CarouselContent>
            <CarouselItem v-for="(_, index) in 10" :key="index">
              <div class="p-1">
                <Card>
                  <CardContent class="flex items-center justify-center p-6">
                    <img src="/img/listing_placeholder_2.jpg" alt="">
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
            <CarouselItem v-for="(_, index) in 10" :key="index" class="pl-0 basis-1/4 cursor-pointer" @click="onThumbClick(index)">
              <div class="p-1" :class="index === selectedIndex ? '' : 'opacity-50'">
                <Card>
                  <CardContent class="flex aspect-square items-center justify-center p-3">
                    <img src="/img/listing_placeholder_2.jpg" alt="">
                  </CardContent>
                </Card>
              </div>
            </CarouselItem>
          </CarouselContent>
        </Carousel>
    </div>
  </div>
</template>