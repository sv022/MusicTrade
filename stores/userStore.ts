import type { IUser } from "~/types/user.interface";

const mockUser = {
    id: 1,
    username: "svo",
    email: "test@mail.com",
    password: "11112222",
    city: "msk",
    phone: "-",
    signupdate: "2024/05/24"
} as IUser;

export const useUserStore = defineStore('UserStore', () => {
    const user = ref<null | IUser>(null);
    const token = useCookie("_token");
    const refreshToken = useCookie("_tokenRefresh");
    const isAuth = ref(!(!token.value) || false);
    const errorAuth = ref(false);
    const errorMsg = ref('');

    const { onLogin, getUser, onSignUp } = useAuth();

    if (isAuth) user.value = mockUser;

    const userSingUp = async (userInfo : IUser) => {
        // const responce = await onSignUp(userInfo);
        navigateTo('/signin');
        // try {
        // } catch (e) {
        //     errorAuth.value = true;
        //     errorMsg.value = "Неверно введены данные или аккаунта не существует";
        //     setTimeout(() => {
        //         errorAuth.value = false;
        //         errorMsg.value = "";
        //     }, 2000);
        //     console.log(e)
        // }
    }

    const userLogin = async (userInfo : { username: string, password: string }) => {
        try {
            // // const responce = await onLogin(userInfo);

            // token.value = responce.data.token;
            // refreshToken.value = responce.data.refreshToken;
            
            // const currentUser = await getUser();
            user.value = mockUser; 
            isAuth.value = true;
            token.value = "token";
            refreshToken.value = "refreshToken";

            navigateTo('/');
        } catch (e) {
            errorAuth.value = true;
            errorMsg.value = "Неверно введены данные или аккаунта не существует";
            setTimeout(() => {
                errorAuth.value = false;
                errorMsg.value = "";
            }, 2000);
            console.log(e)
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
        userLogin,
        userLogout
    }
})