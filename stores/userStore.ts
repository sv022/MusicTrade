import type { IUser, IUserLogin } from "~/types/user.interface";

export const useUserStore = defineStore('UserStore', () => {
    const isAuth = ref(false);
    const user = ref({} as IUser);
    const token = ref('');
    const refreshToken = ref('');
    const errorAuth = ref(false);
    const errorMsg = ref('');   

    const userSingUp = (userInfo : IUser) => {
        user.value = userInfo;
    }

    const userLogin = (userInfo : IUserLogin) => {
        if (userInfo.username == user.value.username && userInfo.password == user.value.password) {
            isAuth.value = true;
            token.value = "token";
            refreshToken.value = "refreshToken";
            errorAuth.value = false;
            errorMsg.value = "";
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