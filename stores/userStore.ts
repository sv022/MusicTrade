import type { IUser, IUserLogin } from "~/types/user.interface";

export const useUserStore = defineStore('UserStore', () => {
    const isAuth = ref(false || !(!(localStorage.getItem("_token"))));
    const user = ref({username: "" || localStorage.getItem("_cachedUserData"), password: ""} as IUser);
    const token = ref('' || localStorage.getItem("_token"));
    const refreshToken = ref('' || "_tokenRefresh");
    const errorAuth = ref(false);
    const errorMsg = ref('');   

    const userSingUp = (userInfo : IUser) => {
        user.value = userInfo;
        navigateTo('/signin');
    }

    const userLogin = (userInfo : IUserLogin) => {
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
        userLogin
    }
})