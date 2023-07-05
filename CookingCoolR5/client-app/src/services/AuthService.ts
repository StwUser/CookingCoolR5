import HttpService from "./HTTP.service";

const GET_TOKEN = "auth/getToken";
const REGISTER_NEW_USER = "auth/register"

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

class AuthService extends HttpService {
  constructor() {
    super("");
  }

  public async getToken(query: IAuth): Promise<IUser> {
    return await this.API.post(GET_TOKEN, query).then((res) => res.data);
  }

  public async registerUser(query: IRegistration): Promise<string> {
    return await this.API.post(REGISTER_NEW_USER, query).then((res) => res.data);
  }
}

export const authService = new AuthService();
