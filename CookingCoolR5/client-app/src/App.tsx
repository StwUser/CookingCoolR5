import React, { useEffect, useState } from 'react';
import './App.css';
import { IUser } from './services/Interfaces';
import LoginForm from './components/loginform/LoginForm';
import OldTv from './components/tvold/TvOld';
import { Route, Routes, useLocation } from 'react-router-dom';
import GamesWithSales from './components/gameswithsales/GamesWithSales';
import Navigation from './components/navigation/Navigation';

function App() {
  const [user, setUser] = useState<IUser | undefined>(undefined);
  const [userWasUpdated, setUpUserWasUpdated] = useState<boolean>(false);
  const location = useLocation();
  const currentLocation = location.pathname; 

  const setUpCss = () => {
    const appDiv = document.getElementById('Application');
    if (appDiv !== null && currentLocation !== '/') {
      appDiv!.style.justifyContent = 'start';
    }
    else if (appDiv !== null) {
      appDiv!.style.justifyContent = 'center';
    }
  }

  setUpCss();

  useEffect(() => {

    if (!userWasUpdated) {
      setUpUser();
    }
  }, [user, userWasUpdated]);

  const setUpUser = () => {
    const userItem = sessionStorage.getItem('user');

    if (userItem !== null) {
      const userRes = JSON.parse(userItem);
      setUser(userRes)
    }
    setUpUserWasUpdated(true);
  }

  return (
    <div className="App" id="Application">
        {user !== undefined && currentLocation !== '/' && <Navigation />}
        <Routes>
          <Route path="/" element={<LoginForm setUser={setUser} />} />
          <Route path="/GamesWithSales" element={<GamesWithSales user={user} />} />
        </Routes>
        {user !== undefined && currentLocation !== '/' && <OldTv />}
    </div>
  );
}

export default App;
