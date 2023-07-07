import React, { useEffect } from "react";
import { IGameModel } from "../../services/Interfaces";
import "./GamesContent.css";
import OldTv from "../../img/old-tv.png";
import { randomIntFromInterval } from "../../services/Helpers/HelpFunctions"

interface IGamesContent {
    games: IGameModel[] | undefined
}

function GamesContent({ games }: IGamesContent): JSX.Element {

    const updateTv = async () => {

        const tvBack = document.getElementById("TvBack") as HTMLElement;
        const lastClassName = tvBack.classList[tvBack.classList.length - 1];
        tvBack.classList.remove(lastClassName);

        const gifN = randomIntFromInterval(0, 7);
        tvBack.classList.add(`Image${gifN}`);
    }

    useEffect(() => {

        if (games === undefined) {
            const intervalTv = setInterval(updateTv, 15000);

            return () => {
                if (games === undefined) {
                    clearInterval(intervalTv);
                }
            };
        }

    }, []);

    if (games === undefined) {
        return (
            <div className="Await-bg Image1" id="TvBack">
                <img src={OldTv} className="OldTv-img" alt="OldTv" />
            </div>
        );
    }
    else {
        return (
            <div className="Games-gal">
                hello games gal
            </div>
        );
    }
}
export default GamesContent;