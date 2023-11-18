import axios from "axios";
import ProjectHelper from "./Helpers/ProjectHelper";
import { IAddGameToCollection, IGameModel, IGamesFilter, IGetUserGames } from "./Interfaces";

const GET_GAMES = "games";
const ADD_GAME = "addGame";
const GET_USER_GAMES = "gamesByUserId";

export class GameService {
  TOKEN: string = "empty";

  public setUpToken(token: string) {
    this.TOKEN = token;
  }

  API = axios.create({
    baseURL: ProjectHelper.isDevelopment ? 'http://localhost:15304/api/' : 'http://cookingcoolr5.somee.com/api/',
    timeout: 1000 * 60 * 3
  });

  public getGamesFilter = (): IGamesFilter | null => { 

    return {
        showGamesFromSteam: true,
        showGamesFromEpicGames: false,
        showGamesFromGog: false,
        getDuplicates: false,
        discount: 0,
        priceFrom: 0,
        priceTo: 0,
        searchWord: '',
        sortByPrice: 1,
        sortByRelevance: 1
    };
  };

  public async getGames(query: IGamesFilter | null): Promise<IGameModel[]> {
    return await this.API.post(GET_GAMES, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }

    public async addGame(query: IAddGameToCollection | null): Promise<string> {
    return await this.API.post(ADD_GAME, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }

  public async getGamesByUserId(query: IGetUserGames | null): Promise<IGameModel[]> {
    return await this.API.post(GET_USER_GAMES, query, { headers: { Authorization: "Bearer " + this.TOKEN }}).then((res) => res.data);
  }
}
