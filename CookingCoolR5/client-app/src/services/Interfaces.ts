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
