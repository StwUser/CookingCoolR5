import React, { useEffect, useState } from "react";
import { IGameItem, IUser } from "../../services/Interfaces";
import { GameService } from "../../services/GameService";
import "./GameItem.css";
import GogI from "../../img/gog.png";
import SteamI from "../../img/steam.png";
import EpicI from "../../img/epic.png";
import { showPopup } from "../../services/Helpers/Popup";

function GameItem({game}: IGameItem): JSX.Element {

    const [isGog, setIsGog] = useState<boolean>(game?.site === 'GOG');
    const [isSteam, setIsSteam] = useState<boolean>(game?.site === 'STeam');
    const [isEpic, setIsEpic] = useState<boolean>(game?.site === 'Epic Games');
    const [user, setUser] = useState<IUser>();

    const gameService = new GameService();
    gameService.setUpToken(user?.accessToken ?? '');

    const setUpUser = () => {
        const userItem = sessionStorage.getItem('user');

        if (userItem !== null) {
          const userRes = JSON.parse(userItem) as IUser;
          setUser(userRes);
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
    }, [game]);    

    return (
        <div key={game?.id} className="Game-item">
            <div className="Store-div">
                <span className="Store-l">{game?.site}</span>
                <div className="Free-space-h"></div>
                {isGog && <img src={GogI} className="Store-img-c" alt="GOG"></img>}
                {isSteam && <img src={SteamI} className="Store-img-c" alt="Steam"></img>}
                {isEpic && <img src={EpicI} className="Store-img-c" alt="Epic Games"></img>}
            </div>
            <div className="Store-game-n">{game?.name}</div>
            <img src={game?.image} className="Game-img-c" alt={game?.name} />
            <div className="Image-free-space">
            </div>
            <div><span className="Old-price">{game?.priceWithoutDiscount}</span><span className="Discount-p">{game?.discount}</span></div>
            <div className="Price-now">{game?.price}</div>
            <div className="Info-block">
                <div className="Add-game" onClick={addGame} >Add game to my collection</div>
                <a href={game?.href} target="_blank" rel="noreferrer" className="Site-page">Site page</a>
            </div>
        </div>
    );
}
export default GameItem;