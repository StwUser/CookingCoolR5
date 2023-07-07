import React from "react";
import { IGameModel } from "../../services/Interfaces";
import "./GamesContent.css";
import Totoro from "../../img/totoro.webp";

interface IGamesContent {
    games: IGameModel[] | undefined
}

function GamesContent({ games }: IGamesContent): JSX.Element {

    return (
        <div className="Await-bg">
            <img src={Totoro} className="Totoro-bg" alt="Totoro" />
        </div>
    );
}
export default GamesContent;