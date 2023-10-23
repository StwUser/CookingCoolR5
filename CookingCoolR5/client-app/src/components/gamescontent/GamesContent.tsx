import React, { useEffect } from "react";
import spinner from '../../img/spinner.gif';
import { IGameModel } from "../../services/Interfaces";
import GameItem from "../gameitem/GameItem";
import "./GamesContent.css";

interface IGamesContent {
    games: IGameModel[] | undefined,
    showSpinner: boolean
}

function GamesContent({ games, showSpinner }: IGamesContent): any {

    useEffect(() => {

    }, [games]);

    if (games === undefined) {
        return showSpinner ? (<img src={spinner} className="Set-up-s" alt="spinner" />) : (<p className="Set-up-p">Set Up filters and push Go.</p>);
    }
    else {
        return (
        <div className="Content-games-c">
            {games.map((g) => { return <GameItem key={g.id} game={g} /> })}
        </div>
        );
    }
}
export default GamesContent;