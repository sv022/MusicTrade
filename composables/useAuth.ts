import type { AxiosResponse } from "axios";
import type { IUser, IUserAuth } from "~/types/user.interface";


export default function useUserAuth() {
    const { $api } = useNuxtApp();

    const onSignUp = async (userInfo: IUser) => {
        const resp = await $api.post("/auth/register", userInfo);
        return resp;
    }

    const onLogin = async (loginData: {username: string, password: string}) : Promise<AxiosResponse<IUserAuth>> => {
        const resp = await $api.post("/auth/login", loginData);
        return resp;
    }

    const getUser = async (): Promise<AxiosResponse<IUser>> => {
        const resp = await $api.get("/auth/me", {
          headers: { Authorization: `Bearer ${useCookie("_token").value}` },
        });
        return resp;
    };

    return {
        onSignUp,
        onLogin,
        getUser
    }
}