import axios from "axios";
import ProjectHelper from "./Helpers/ProjectHelper";
import { IAddGameToCollection, IGameModel, IGamesFilter } from "./Interfaces";

const GET_GAMES = "games";
const ADD_GAME = "addGame";

export class GameService {
  TOKEN: string = "empty";

  public setUpToken(token: string) {
    this.TOKEN = token;
  }

  API = axios.create({
    baseURL: ProjectHelper.isDevelopment ? 'http://localhost:15304/api/' : 'http://cookingcoolr5.somee.com/api/',
    timeout: 1000 * 60 * 3
  });

  public async getGames(query: IGamesFilter | null): Promise<IGameModel[]> {
    return await this.API.post(GET_GAMES, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }

    public async addGame(query: IAddGameToCollection | null): Promise<string> {
    return await this.API.post(ADD_GAME, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }
}
