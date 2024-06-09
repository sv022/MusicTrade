import axios from "axios";

export default defineNuxtPlugin((nuxtApp) => {
  const config = useRuntimeConfig();
  //api main
  const api = axios.create();
  api.defaults.baseURL = config.public.API_MUSICTRADE_BACK as string;

  return {
    provide: {
      api: api,
    },
  };
});