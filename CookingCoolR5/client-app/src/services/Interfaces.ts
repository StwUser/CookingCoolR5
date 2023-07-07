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

