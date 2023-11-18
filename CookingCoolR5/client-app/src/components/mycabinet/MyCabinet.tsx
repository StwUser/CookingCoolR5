import { useEffect, useState } from "react";
import "./MyCabinet.css";
import NoPhoto from "../../img/no-photo.jpg";
import { GameService } from "../../services/GameService";
import { IContentFormData, IGameModel } from "../../services/Interfaces"
import spinner from '../../img/spinner.gif';
import { useNavigate } from 'react-router-dom';
import Video from "../../vid/galaxy.mp4";
import { SteamApiService } from "../../services/SteamApiService";
import { ISteamGameModel } from "../../services/InterfacesSteam";
import GameFullInfo from "../gamesteaminfo/GameFullInfo";


function MyCabinet({ user }: IContentFormData): JSX.Element {

    const [games, setGames] = useState<IGameModel[]>();
    const [currentGame, setCurrentGame] = useState<IGameModel>();
    const [gameFromSteam, setGameFromSteam] = useState<ISteamGameModel>();
    const navigate = useNavigate();
    const [gamesIsLoaded, setGamesIsLoaded] = useState<boolean>(false);
    const [currentGameIsChosen, setCurrentGameIsChosen] = useState<boolean>(false);

    const setUpCurrentGame = (game: IGameModel): void => {
        setCurrentGame(game);
        setCurrentGameIsChosen(true);
    };

    useEffect(() => {
        const gameService = new GameService();
        gameService.setUpToken(user?.accessToken ?? '');
        const steamApiService = new SteamApiService();
        steamApiService.setUpToken(user?.accessToken ?? '');

        const getGames = async (userId: number): Promise<IGameModel[]> => {
            const res = await gameService.getGamesByUserId({ userId: userId });
            return res;
        }

        const setUpGameFromSteam = async (): Promise<void> => {
            const gameByName = await steamApiService.getGameByName({ gameName: currentGame?.name ?? "" });
            setGameFromSteam(gameByName);
        }
    
        const fetchGames = async (): Promise<void> => {
            const result = await getGames(user!.userId);
            setGames(result);
            setGamesIsLoaded(true);
        };

        if (user === undefined) {
            navigate("/");
        }

        fetchGames();
        if (currentGameIsChosen) {
            setUpGameFromSteam();
        }
    }, [navigate, user, currentGame, currentGameIsChosen]);

    return (
        <div className="With-flex">
            <div className="Content-row-header">
                <div className="Nav-item">
                    <img src={NoPhoto} className="No-photo-icon" alt="NoPhoto" />
                    <span className="About-page">{user?.userName}</span>
                </div>
                <div className="Nav-item">
                    some info
                </div>
                <div className="Nav-item">
                    some info
                </div>
                <div className="Nav-item">
                    some info
                </div>
            </div>
            <div className="Content-games-cab">
                <div className="Content-column-left">
                    <div className="Content-column-col">
                        <div className="Content-column-left-head">Collection</div>
                        {
                            gamesIsLoaded && games?.map(g =>
                            (<div onClick={() => {
                                setUpCurrentGame(g)
                            }} className={g.id === currentGame?.id ? "Content-column-left-content Game-is-active" : "Content-column-left-content"} key={g.id}>{g.name}</div>))
                        }
                    </div>
                </div>
                <div className="Content-column-center">

                    {
                        currentGameIsChosen && gameFromSteam !== undefined ? (<GameFullInfo game={currentGame} steamGame={gameFromSteam} />) : (<img src={spinner} className="Set-up-s" alt="spinner" />)
                    }
                </div>
            </div>
            <video width="300px" height="300px" controls autoPlay loop muted>
                        <source src={"https://images.all-free-download.com/footage_preview/mp4/3d_clip_of_black_hole_motion_6891983.mp4"} type="video/mp4" />
                        <source src={Video} type="video/mp4" />
            </video>
        </div>
    );
}
export default MyCabinet;