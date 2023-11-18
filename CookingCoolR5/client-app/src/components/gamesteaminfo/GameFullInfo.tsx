import React, { useEffect, useState } from "react";
import { IUser } from "../../services/Interfaces";
import { GameService } from "../../services/GameService";
import "./GameFullInfo.css";
import GogI from "../../img/gog.png";
import SteamI from "../../img/steam.png";
import EpicI from "../../img/epic.png";
import { showPopup } from "../../services/Helpers/Popup";
import { IGameFullInfo } from "../../services/InterfacesSteam";

function GameItem(info: IGameFullInfo | null): JSX.Element {

    const game = info!.game;
    const steamGame = info!.steamGame;
    const [isGog, setIsGog] = useState<boolean>(game?.site === 'GOG');
    const [isSteam, setIsSteam] = useState<boolean>(game?.site === 'STeam');
    const [isEpic, setIsEpic] = useState<boolean>(game?.site === 'Epic Games');
    const [user, setUser] = useState<IUser>();

    const gameService = new GameService();
    gameService.setUpToken(user?.accessToken ?? '');

    const setUpUser = () : void => {
        const userItem = sessionStorage.getItem('user');

        if (userItem !== null) {
          const userRes = JSON.parse(userItem) as IUser;
          setUser(userRes);
        }
    }

    const setUpBackground = () : void => {
        console.log("steamGame", steamGame);
        console.log("steamGame?.data", steamGame?.data);
        
        const infoDiv = document.getElementById('Game-info-container') as HTMLElement;
        if (infoDiv !== null && steamGame?.data?.background !== null) {
          infoDiv.style.backgroundImage = `url(${steamGame?.data?.background})`;
        }
    }

    const addGame = async () : Promise<void> => {
        var result = await gameService.addGame({ userId: user?.userId ?? null, gameId: game?.id ?? null });

        showPopup(result);
    }

    useEffect(() => {
        setUpUser();

        setIsGog(game?.site === 'GOG');
        setIsSteam(game?.site === 'Steam');
        setIsEpic(game?.site === 'Epic Games');
        
        setUpBackground();
    }, [game, steamGame]);    

    return (
        <div key={game?.id} className="Game-info-container" id="Game-info-container">
            <div className="Game-Info-raw1">
                <div>{steamGame?.data?.name}</div>
                <div></div>
                <a href={game?.href} title="to site">Site page</a>
                <div className="Game-info-site-logo">
                    {isGog && <img src={GogI} className="Store-img-c" alt="GOG"></img>}
                    {isSteam && <img src={SteamI} className="Store-img-c" alt="Steam"></img>}
                    {isEpic && <img src={EpicI} className="Store-img-c" alt="Epic Games"></img>}                    
                </div>
            </div>
        </div>
    );
}
export default GameItem;