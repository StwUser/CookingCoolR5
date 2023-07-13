import React, { useEffect, useState } from "react";
import { IGameItem } from "../../services/Interfaces";
import "./GameItem.css";
import GogI from "../../img/gog.png";
import SteamI from "../../img/steam.png";
import EpicI from "../../img/epic.png";

function GameItem({game}: IGameItem): JSX.Element {

    const [isGog, setIsGog] = useState<boolean>(game?.site === 'GOG');
    const [isSteam, setIsSteam] = useState<boolean>(game?.site === 'STeam');
    const [isEpic, setIsEpic] = useState<boolean>(game?.site === 'Epic Games');

    console.log('name ', game?.name, 'isEpic', isEpic);

    useEffect(() => {

        setIsGog(game?.site === 'GOG');
        setIsSteam(game?.site === 'Steam');
        setIsEpic(game?.site === 'Epic Games');        
    }, [game]);    

    return (
        <div key={game?.id} className="Game-item">
            <div className="Store-div">
                <span className="Store-l">{game?.site}</span>
                {isGog && <img src={GogI} className="Store-img-c" alt="GOG"></img>}
                {isSteam && <img src={SteamI} className="Store-img-c" alt="Steam"></img>}
                {isEpic && <img src={EpicI} className="Store-img-c" alt="Epic Games"></img>}
            </div>
            <div className="Store-game-n">{game?.name}</div>
            <img src={game?.image} className="Game-img-c" alt={game?.name} />
            <div><span className="Old-price">{game?.priceWithoutDiscount}</span><span className="Discount-p">{game?.discount}</span></div>
            <div className="Price-now">{game?.price}</div>
            <a href={game?.href} target="_blank" rel="noreferrer" className="Site-page">Site page</a>
        </div>
    );
}
export default GameItem;