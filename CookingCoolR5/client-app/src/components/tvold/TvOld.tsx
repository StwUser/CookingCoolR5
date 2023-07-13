import React, {useState} from "react";
import "./TvOld.css";
import OldTv from "../../img/old-tv.png";

function TvOld(): JSX.Element {
    const [gifN, setGifN] = useState<number>(1);

    const updateGifN = () => {
        
        if(7 <= gifN)
        {
            setGifN(1);
        }
        else
            setGifN(gifN + 1);
    }

    const updateTv = async () => {

        const tvBack = document.getElementById("TvBack") as HTMLElement;
        const lastClassName = tvBack.classList[tvBack.classList.length - 1];
        tvBack.classList.remove(lastClassName);

        tvBack.classList.add(`Image${gifN}`);
        updateGifN();
    }

    return (
        <div onClick={updateTv} className="Await-bg Image0" id="TvBack">
            <img src={OldTv} className="OldTv-img" alt="OldTv" />
        </div>
    );
}
export default TvOld;