import React, { useState, useEffect } from "react";
import logo from '../../logo3.png';
import "./LoginForm.css";
import Authorization from '../authorization/Authorization';
import Registration from "../registration/Registration";

function LoginForm({ setUser }: any): JSX.Element {

    const [isRegistration, setRegistration] = useState<boolean>(false);

    useEffect(() => {

    }, [isRegistration]);

    return (
        <div className="App-content">
            <img src={logo} className="App-logo" alt="logo" />
            {!isRegistration && <Authorization setUser={setUser} setRegistration={setRegistration} />}
            {isRegistration && <Registration setRegistration={setRegistration} />}
        </div>
    );
}
export default LoginForm;