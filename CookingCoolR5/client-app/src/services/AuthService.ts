import axios from "axios";
import { IAuth, IUser, IRegistration } from "./Interfaces";
import ProjectHelper from "./Helpers/ProjectHelper";
const GET_TOKEN = "auth/getToken";
const REGISTER_NEW_USER = "auth/register";

export class AuthService {

  API = axios.create({
    baseURL: ProjectHelper.isDevelopment ? 'http://localhost:15304/api/' : 'http://cookingcoolr5.somee.com/api/',
    timeout: 1000 * 60 * 3
  });

  public async getToken(query: IAuth): Promise<IUser> {
    return await this.API.post(GET_TOKEN, query).then((res) => res.data);
  }

  public async registerUser(query: IRegistration): Promise<string> {
    return await this.API.post(REGISTER_NEW_USER, query).then((res) => res.data);
  }
}

