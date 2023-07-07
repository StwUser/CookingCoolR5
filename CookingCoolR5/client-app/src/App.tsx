import React, { useEffect, useState } from 'react';
import './App.css';
import { IUser } from './services/Interfaces';
import LoginForm from './components/loginform/LoginForm';
import ContentForm from './components/contentform/ContentForm';

function App() {
  const [user, setUser] = useState<IUser | null>(null);
  const setUpCss = () => {
    const appDiv = document.getElementById('Application');
    if (appDiv !== null && user !== null) {
      appDiv!.style.justifyContent = 'start';
    }
    else if (appDiv !== null) {
      appDiv!.style.justifyContent = 'center';
    }
  }

  setUpCss();

  useEffect(() => {

  }, [user]);

  return (
    <div className="App" id="Application">
      {user === null && <LoginForm setUser={setUser} />}
      {user !== null && <ContentForm user={user} />}
    </div>
  );
}

export default App;
