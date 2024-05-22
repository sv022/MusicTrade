import type { IUser } from "~/types/user.interface";

function getLocalItem(name : string){
    if (typeof window === 'object' || typeof window !== 'undefined') {
        const item = localStorage.getItem(name);
        return item || "";
    }
    return "";
}

export const useUserStore = defineStore('UserStore', () => {
    const user = ref({username: getLocalItem("_cachedUserData"), password: ""} as IUser);
    const token = ref(getLocalItem("_token"));
    const refreshToken = ref(getLocalItem("_tokenRefresh"));
    const isAuth = ref(!(!token.value) || false);
    const errorAuth = ref(false);
    const errorMsg = ref('');   

    const userSingUp = (userInfo : IUser) => {
        user.value = userInfo;
        navigateTo('/signin');
    }

    const userLogin = (userInfo : { username: string, password: string }) => {
        if (userInfo.username == user.value.username && userInfo.password == user.value.password) {
            isAuth.value = true;
            token.value = "token";
            refreshToken.value = "refreshToken";
            errorAuth.value = false;
            errorMsg.value = "";

            localStorage.setItem("_token", token.value);
            localStorage.setItem("_tokenRefresh", refreshToken.value);
            localStorage.setItem("_cachedUserData", userInfo.username);

            navigateTo('/');

        } else {
            errorAuth.value = true;
            errorMsg.value = "Неверно введены данные или аккаунта не существует";
            setTimeout(() => {
                errorAuth.value = false;
                errorMsg.value = "";
            }, 2000);
        }
    }

    const userLogout = () => {
        isAuth.value = false;
        user.value = {} as IUser;
        token.value = "";
        refreshToken.value = "";

        localStorage.setItem("_token", "");
        localStorage.setItem("_tokenRefresh", "");
        localStorage.setItem("_cachedUserData", "");

        navigateTo('/');
    }

    return {
        isAuth,
        user,
        token,
        refreshToken,
        errorAuth,
        errorMsg,
        // Methods
        userSingUp,
        userLogin,
        userLogout
    }
})