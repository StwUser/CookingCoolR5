import React, { useEffect, useState } from 'react';
import './App.css';
import { IUser } from './services/AuthService';
import LoginForm from './components/loginform/LoginForm';

function App() {
  const [user, setUser] = useState<IUser | null>(null);

  useEffect(() => {

    console.log(user)
  }, [user]);

  return (
    <div className="App">
      <LoginForm setUser={setUser} />
    </div>
  );
}

export default App;
