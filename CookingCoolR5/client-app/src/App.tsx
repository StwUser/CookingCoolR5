import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import { IUser } from './services/AuthService';
import Authorization from './components/authorization/Authorization';

function App() {

  const [user, setUser] = useState<IUser | null>(null);
  const [isRegistration, setRegistration] = useState<boolean>(false);

  useEffect(() => {

    console.log(user)
    console.log(isRegistration)
  }, [user, isRegistration]);

  return (
    <div className="App">
      <div className="App-content">
        <img src={logo} className="App-logo" alt="logo" />
        <Authorization setUser={setUser} setRegistration={setRegistration} />
      </div>
    </div>
  );
}

export default App;
