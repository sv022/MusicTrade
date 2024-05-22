import type { IUser } from "./user.interface";

export interface IListing {
    id: number,
    owner: IUser,
    title: string,
    price: number,
    category: string,
    isExchangable: boolean,
    description: string,
    adress: string,
    tags: string,
    publishDate: string,
    img: string[]
}