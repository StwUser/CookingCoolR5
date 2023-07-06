import React, { useState } from "react";
import "./Navigation.css";
import StoreIcon from "../../img/store-icon3.png";
import TargetIcon from "../../img/target2.png";

function Navigation(): JSX.Element {

    const [width, setWidth] = useState<number>(100);

    const changeWidth = (event: any) => {
        setWidth(event.target.value);
    };

    return (
        <div className="Content-row-header">
            <div className="Nav-item">
                <img src={StoreIcon} className="Store-icon" alt="StoreIcon" />
            </div>
            <div className="Nav-item">
                <span className="Logo-text">Game Stores</span>
                <div>
                    <input type="checkbox" className="Checkbox-nav"></input>
                    <label className="Options-text">Steam</label>
                </div>
                <div>
                    <input type="checkbox" className="Checkbox-nav"></input>
                    <label className="Options-text">Epic Games</label>
                </div>
                <div>
                    <input type="checkbox" className="Checkbox-nav"></input>
                    <label className="Options-text">GOG</label>
                </div>
            </div>
            <div className="Nav-item">
                <span className="Logo-text Align-self-center">Options</span>
                <div className="Duplicates-div">
                    <input type="checkbox" className="Checkbox-nav"></input>
                    <label className="Options-text">show duplicates</label>
                </div>
                <label className="Options-text Align-self-center">discount &nbsp;&nbsp;{width}%</label>
                <input type='range' onChange={changeWidth} min={0} max={100} step={1} value={width} className="Align-self-center Range-style"></input>
            </div>
            <div className="Nav-item">
                <span className="Logo-text Align-self-center">Price</span>
            </div>
            <div className="Nav-item">
                <div>
                    <span className="Logo-text">Search</span>
                    <img src={TargetIcon} className="Target-icon" alt="TargetIcon" />
                </div>
            </div>
        </div>
    );
}
export default Navigation;