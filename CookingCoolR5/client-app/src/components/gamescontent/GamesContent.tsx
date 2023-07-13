import React, { useEffect } from "react";
import { IGameModel } from "../../services/Interfaces";
import "./GamesContent.css";

interface IGamesContent {
    games: IGameModel[] | undefined
}

function GamesContent({ games }: IGamesContent): JSX.Element {

    useEffect(() => {

    }, []);

    return (
        <div className="Games-gal">
        </div>
    );
}
export default GamesContent;