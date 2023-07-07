import React, { useEffect } from "react";
import { IGameModel } from "../../services/Interfaces";
import "./GamesContent.css";
import OldTv from "../../img/old-tv.png";
import { timeOut, randomIntFromInterval } from "../../services/Helpers/HelpFunctions"

interface IGamesContent {
    games: IGameModel[] | undefined
}

function GamesContent({ games }: IGamesContent): JSX.Element {

    const updateTv = async () => {

        const tvBack = document.getElementById("TvBack") as HTMLElement;
        const lastClassName = tvBack.classList[tvBack.classList.length - 1];
        tvBack.classList.remove(lastClassName);
        tvBack.classList.add('Image0');
        await timeOut(3500);
        const gifN = randomIntFromInterval(1, 4);
        tvBack.classList.remove('Image0');
        tvBack.classList.add(`Image${gifN}`);
    }

    useEffect(() => {

        const intervalTv = setInterval(updateTv, 30000);

        return () => {
            console.log("cleaned up");
            clearInterval(intervalTv);
        };
    }, []);

    return (
        <div className="Await-bg Image1" id="TvBack">
            <img src={OldTv} className="OldTv-img" alt="OldTv" />
        </div>
    );
}
export default GamesContent;