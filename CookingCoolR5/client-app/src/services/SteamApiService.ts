import axios from "axios";
import ProjectHelper from "./Helpers/ProjectHelper";
import { IGetGameByName, ISteamGameModel } from "./InterfacesSteam";

const GET_GAME_BY_NAME = "game";

export class SteamApiService {
  TOKEN: string = "empty";

  public setUpToken(token: string) {
    this.TOKEN = token;
  }

  API = axios.create({
    baseURL: ProjectHelper.isDevelopment ? 'http://localhost:15304/api/' : 'http://cookingcoolr5.somee.com/api/',
    timeout: 1000 * 60 * 3
  });

  public async getGameByName(query: IGetGameByName | null): Promise<ISteamGameModel> {
    return await this.API.post(GET_GAME_BY_NAME, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }
}
