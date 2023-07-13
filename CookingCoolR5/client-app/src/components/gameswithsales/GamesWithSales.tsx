import React, { useEffect, useState } from "react";
import "./GamesWithSales.css";
import StoreIcon from "../../img/store-icon.png";
import TargetIcon from "../../img/target.png";
import { GameService } from "../../services/GameService";
import { IContentFormData, IGamesFilter, IGameModel } from "../../services/Interfaces"
import GamesContent from "../gamescontent/GamesContent";
import { useNavigate } from 'react-router-dom';


function GamesWithSales({ user }: IContentFormData): JSX.Element {

    const [discount, setDiscount] = useState<number>(0);
    const [priceFrom, setPriceFrom] = useState<number>(0);
    const [priceTo, setPriceTo] = useState<number>(300);
    const [games, setGames] = useState<IGameModel[]>();
    const [gamesWereLoaded, setGamesWereLoaded] = useState<boolean>(false);
    const navigate = useNavigate();

    const gameService = new GameService();
    gameService.setUpToken(user?.accessToken ?? '');

    const changeDiscount = (event: any) => {
        setDiscount(event.target.value);
    };
    const changePriceFrom = (event: any) => {
        setPriceFrom(event.target.value);
    };
    const changePriceTo = (event: any) => {
        setPriceTo(event.target.value);
    };

    const getGamesFilter = (): IGamesFilter | null => {
        const steamCb = document.querySelector('input[name="SteamCb"]') as HTMLInputElement;
        const epicGamesCb = document.querySelector('input[name="EpicGamesCb"]') as HTMLInputElement;
        const gogCb = document.querySelector('input[name="GogCb"]') as HTMLInputElement;
        const showDupCb = document.querySelector('input[name="ShowDupCb"]') as HTMLInputElement;
        const search = document.querySelector('input[name="Search"]') as HTMLInputElement;

        return {
            showGamesFromSteam: steamCb.checked,
            showGamesFromEpicGames: epicGamesCb.checked,
            showGamesFromGog: gogCb.checked,
            getDuplicates: showDupCb.checked,
            discount: discount,
            priceFrom: priceFrom,
            priceTo: priceTo,
            searchWord: search.value
        };
    };

    const getGames = async (): Promise<IGameModel[]> => {
        const gamesFilter = getGamesFilter();
        const res = await gameService.getGames(gamesFilter);
        return res;
    }

    const fetchGames = async (): Promise<void> => {
        const result = await getGames();
        setGames(result);
        const jSonStr = JSON.stringify(result);
        sessionStorage.setItem('games', jSonStr);
    };

    const getGamesFromStorage = (): void => {
        const gamesItem = sessionStorage.getItem('games');

        if (gamesItem !== null) {
            const gamesRes = JSON.parse(gamesItem);
            setGames(gamesRes)
        }
        setGamesWereLoaded(true);
    }

    useEffect(() => {

        if (user === undefined) {
            navigate("/");
        }

        if (!gamesWereLoaded) {
            getGamesFromStorage();
        }
    }, [gamesWereLoaded]);

    return (
        <div className="With-flex">
            <div className="Content-row-header">
                <div className="Nav-item">
                    <span className="About-page">Games with sales<br />page</span>
                    <img src={StoreIcon} className="Store-icon" alt="StoreIcon" />
                </div>
                <div className="Nav-item Width-140">
                    <span className="Logo-text Align-self-center">Game Stores</span>
                    <div>
                        <input type="checkbox" className="Checkbox-nav" name="SteamCb"></input>
                        <label className="Options-text">Steam</label>
                    </div>
                    <div>
                        <input type="checkbox" className="Checkbox-nav" name="EpicGamesCb"></input>
                        <label className="Options-text">Epic Games</label>
                    </div>
                    <div>
                        <input type="checkbox" className="Checkbox-nav" name="GogCb"></input>
                        <label className="Options-text">GOG</label>
                    </div>
                </div>
                <div className="Nav-item">
                    <span className="Logo-text Align-self-center">Options</span>
                    <div className="Duplicates-div">
                        <input type="checkbox" className="Checkbox-nav" name="ShowDupCb"></input>
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
                    <input type='range' onChange={changePriceTo} min={0} max={300} step={1} value={priceTo} className="Align-self-center Range-style"></input>
                </div>
                <div className="Nav-item">
                    <div>
                        <span className="Logo-text">Search</span>
                        <img src={TargetIcon} className="Target-icon" alt="TargetIcon" />
                    </div>
                    <input className="Search-input" placeholder="search" name="Search"></input>
                    <button onClick={fetchGames} className="Go-btn">Go</button>
                </div>
            </div>
            <GamesContent games={games} />
        </div>
    );
}
export default GamesWithSales;