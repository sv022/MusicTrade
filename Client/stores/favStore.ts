import type { IListing } from '@/types/listing.interface'

function getLocalItem(name : string){
    if (typeof window === 'object' || typeof window !== 'undefined') {
        const item = localStorage.getItem(name);
        return item || "";
    }
    return "";
}

export const useFavStore = defineStore('fav', () => {
  let favCount = ref<number>(0);
  let listings = ref<IListing[]>([]);
  // const favCount = ref<number>(0);
  // const listings = ref<IListing[]>([]);

  const toggleFav = (listing: IListing) => {
    const index = listings.value.findIndex((l) => l.id === listing.id);
    if (index === -1) {
        listings.value.push(listing);
        favCount.value++;
        localStorage.setItem('fav', JSON.stringify(listings.value))
        localStorage.setItem('favIndex', JSON.stringify(favCount.value))
        return;
    } 
    listings.value = listings.value.filter((l) => l.id !== listing.id);
    favCount.value--;
    localStorage.removeItem('favIndex')
    localStorage.removeItem('fav')
  }

  onMounted(() => {
    favCount.value = JSON.parse(localStorage.getItem('favIndex') || '0');
    listings.value = JSON.parse(localStorage.getItem('fav') ?? '[]')
  })

  return {
    favCount,
    listings,
    // methods
    toggleFav
  }
})