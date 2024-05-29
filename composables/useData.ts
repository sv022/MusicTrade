import type { AxiosResponse } from "axios";
import type { IUser, IUserAuth } from "~/types/user.interface";


export default function useUserData() {
    const { $api } = useNuxtApp();

    const loadListings = async (userInfo: IUser) => {
        const resp = await $api.get("listings.json");
        return resp;
    }

    return {
        loadListings
    }
}