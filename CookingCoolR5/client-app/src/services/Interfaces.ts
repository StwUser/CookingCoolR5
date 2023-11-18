import { SortType } from "../enums/Enums";

// Auth service
export interface IUser {
  accessToken: string,
  userName: string,
  userId: number,
  userRole: string
}

export interface IAuth {
  username: string;
  password: string;
}

export interface IRegistration {
  email: string,
  name: string,
  userName: string,
  password: string
}

// Games
export interface IGamesFilter {
  discount: number | null;
  priceFrom: number | null;
  priceTo: number | null;
  showGamesFromGog: boolean;
  showGamesFromSteam: boolean;
  showGamesFromEpicGames: boolean;
  getDuplicates: boolean;
  searchWord: string;
  sortByPrice: SortType;
  sortByRelevance: SortType;
}

// Add game to User collection
export interface IAddGameToCollection {
  userId: number | null;
  gameId: number | null;
}

// Get User's games bi UserId
export interface IGetUserGames {
  userId: number | null;
}

export interface IGameModel {
  id: number,
  session: number,
  site: string,
  name: string,
  image: string,
  price: string,
  discount: string,
  priceWithoutDiscount: string,
  href: string,
  created: Date,
  discountInt: number,
  priceDouble: number,
  relevance: number
}

//Navigation
export interface INavigation {
  token: string
} 

export interface IContentFormData {
  user: IUser | undefined
}

export interface IGameItem {
  game: IGameModel | undefined
}

