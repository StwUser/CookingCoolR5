import React from "react";
import { IGameModel } from "../../services/Interfaces";
import "./GamesContent.css";
import OldTv from "../../img/old-tv.png";

interface IGamesContent {
    games: IGameModel[] | undefined
}

function GamesContent({ games }: IGamesContent): JSX.Element {

    return (
        <div className="Await-bg">
            <img src={OldTv} className="OldTv-img" alt="OldTv" />
        </div>
    );
}
export default GamesContent;