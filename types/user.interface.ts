export interface IUser {
    id: number,
    username: string,
    email: string,
    password: string,
    city: string,
    phone: string,
    signupdate: string
}

export interface IUserAuth {
    token: string,
    refreshToken: string
}