import React, { useEffect } from "react";
import { IGameModel } from "../../services/Interfaces";
import GameItem from "../gameitem/GameItem";
import "./GamesContent.css";

interface IGamesContent {
    games: IGameModel[] | undefined
}

function GamesContent({ games }: IGamesContent): any {

    useEffect(() => {

        console.log(games);
    }, [games]);

    if (games === undefined) {
        return (<p className="Set-up-p">Set Up filters and push Go.</p>);
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