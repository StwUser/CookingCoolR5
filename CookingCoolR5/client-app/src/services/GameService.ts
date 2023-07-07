import axios from "axios";
import ProjectHelper from "./Helpers/ProjectHelper";
import { IRegistration } from "./Interfaces";

interface IGamesFilter {
  discount: number | null;
  priceFrom: number | null;
  priceTo: number | null;
  showGamesFromGog: boolean;
  showGamesFromSteam: boolean;
  showGamesFromEpicGames: boolean;
  getDuplicates: boolean;
}

const REGISTER_NEW_USER = "auth/register";

const GET_GAMES = "games";

export class GameService {
  TOKEN: string = "empty";

  public setUpToken(token: string) {
    this.TOKEN = token;
  }

  API = axios.create({
    baseURL: ProjectHelper.isDevelopment ? 'http://localhost:15304/api/' : 'http://cookingcoolr5.somee.com/api/',
    timeout: 1000 * 60 * 3
  });

  public async getGames(query: IGamesFilter | null): Promise<any> {
    return await this.API.post(GET_GAMES, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }

  public async registerUser(query: IRegistration): Promise<string> {
    return await this.API.post(REGISTER_NEW_USER, query).then(
      (res) => res.data
    );
  }
}
