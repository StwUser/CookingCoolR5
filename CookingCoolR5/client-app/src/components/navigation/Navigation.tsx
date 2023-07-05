import React from "react";
import "./Navigation.css";
import StoreIcon from "../../img/store-icon3.png"

function Navigation(): JSX.Element {

    return (
        <div className="Content-row-header">
            <div className="Nav-item Logo-item">
                <div className="Column-div">
                    <div>
                        <img src={StoreIcon} className="Store-icon" alt="StoreIcon" />
                        <span className="Logo-text">Game Stores</span>
                    </div>
                    <div>seeds</div>
                </div>
            </div>
            <div className="Nav-item">2</div>
            <div className="Nav-item">3</div>
            <div className="Nav-item">4</div>
            <div className="Nav-item">5</div>
        </div>
    );
}
export default Navigation;