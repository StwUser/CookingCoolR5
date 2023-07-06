import React, { useEffect, useState } from 'react';
import './App.css';
import { IUser } from './services/AuthService';
import LoginForm from './components/loginform/LoginForm';
import ContentForm from './components/contentform/ContentForm';

function App() {
  const [user, setUser] = useState<IUser | null>(null);

  useEffect(() => {

    const setUpCss = () => {
      const appDiv = document.getElementById('Application');
      if (user !== null) {
        appDiv!.style.justifyContent = 'start';
      }
      else {
        appDiv!.style.justifyContent = 'center';
      }
    }

    setUpCss();


    console.log(user)
  }, [user]);

  return (
    <div className="App" id="Application">
      {user === null && <LoginForm setUser={setUser} />}
      {user !== null && <ContentForm user={user} />}
    </div>
  );
}

export default App;
