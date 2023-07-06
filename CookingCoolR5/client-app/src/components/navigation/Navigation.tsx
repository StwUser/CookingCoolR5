import React from "react";
import "./Navigation.css";
import StoreIcon from "../../img/store-icon3.png"

function Navigation(): JSX.Element {

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
                <span className="Logo-text">Options</span>
                <div>
                    <input type="checkbox" className="Checkbox-nav"></input>
                    <label className="Options-text">show duplicates</label>
                </div>
            </div>
            <div className="Nav-item">3</div>
            <div className="Nav-item">4</div>
            <div className="Nav-item">5</div>
        </div>
    );
}
export default Navigation;