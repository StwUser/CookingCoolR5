import HttpService from "./HTTP.service";

const GET_TOKEN = "auth/getToken";

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

class AuthService extends HttpService {
  constructor() {
    super("");
  }

  public async getToken(query: IAuth): Promise<IUser> {
    console.log(query);
    return await this.API.post(GET_TOKEN, query).then((res) => res.data);
  }
}

export const authService = new AuthService();
