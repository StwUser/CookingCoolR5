import React, { useState } from "react";
import "./Navigation.css";
import StoreIcon from "../../img/store-icon3.png";
import TargetIcon from "../../img/target2.png";

function Navigation(): JSX.Element {

    const [discount, setDiscount] = useState<number>(0);
    const [priceFrom, setPriceFrom] = useState<number>(0);
    const [priceTo, setPriceTo] = useState<number>(300);

    const changeDiscount = (event: any) => {
        setDiscount(event.target.value);
    };
    const changePriceFrom = (event: any) => {
        setPriceFrom(event.target.value);
    };
    const changePriceTo = (event: any) => {
        setPriceTo(event.target.value);
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
                <label className="Options-text Align-self-center">discount &nbsp;&nbsp;{discount}%</label>
                <input type='range' onChange={changeDiscount} min={0} max={100} step={1} value={discount} className="Align-self-center Range-style"></input>
            </div>
            <div className="Nav-item">
                <span className="Logo-text Align-self-center">Price</span>
                <label className="Options-text Align-self-center">from &nbsp;&nbsp;{priceFrom}$</label>
                <input type='range' onChange={changePriceFrom} min={0} max={300} step={1} value={priceFrom} className="Align-self-center Range-style"></input>
                <label className="Options-text Align-self-center">to &nbsp;&nbsp;{priceTo}$</label>
                <input type='range' onChange={changePriceTo} min={0} max={100} step={1} value={priceTo} className="Align-self-center Range-style"></input>
            </div>
            <div className="Nav-item">
                <div>
                    <span className="Logo-text">Search</span>
                    <img src={TargetIcon} className="Target-icon" alt="TargetIcon" />
                </div>
                <input className="Search-input" placeholder="search" name="Search"></input>
                <button >Submit</button>
            </div>
        </div>
    );
}
export default Navigation;