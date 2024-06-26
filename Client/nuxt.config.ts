// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  typescript: { strict: false },
  devtools: { enabled: true },
  modules: ["@nuxtjs/tailwindcss", '@pinia/nuxt', "shadcn-nuxt"],
  runtimeConfig: {
    public: {
      API_MUSICTRADE_BACK: process.env.API_MUSICTRADE_BACK,
    }
  },
})