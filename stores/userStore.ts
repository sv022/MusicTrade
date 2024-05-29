import type { IUser } from "~/types/user.interface";

export const useUserStore = defineStore('UserStore', () => {
    const user = ref<null | IUser>(null);
    const token = useCookie("_token");
    const refreshToken = useCookie("_tokenRefresh");
    const isAuth = ref(!(!token.value) || false);
    const errorAuth = ref(false);
    const errorMsg = ref('');

    const { onLogin, getUser, onSignUp } = useAuth();

    const userSingUp = async (userInfo : IUser) => {
        // const responce = await onSignUp(userInfo);
        // console.log(responce)
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
            // const responce = await onLogin(userInfo);

            // token.value = responce.data.token;
            // refreshToken.value = responce.data.refreshToken;
            token.value = "token";
            refreshToken.value = "refreshToken";
            
            // const currentUser = await getUser();
            user.value = {
                id: 0,
                username: "svo0",
                email: "svo0@mail.com",
                password: "pass1",
                city: "msk",
                phone: "+7 (937) 915 24-12",
                signupdate: "2024-05-27",
                image: "4000"
            }; 
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