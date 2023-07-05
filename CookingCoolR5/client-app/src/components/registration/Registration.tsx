import React, { useState } from "react";
import "./Registration.css";
import { authService, IRegistration } from '../../services/AuthService';

interface IRegistrationForm {
    setRegistration: Function
}

function Registration({ setRegistration }: IRegistrationForm): JSX.Element {

    const [isRegisterSent, setIsRegisterSent] = useState<boolean>(false);

    const registerNewUser = async (query: IRegistration): Promise<string> => {
        const res = await authService.registerUser(query);
        return res as string;
    };

    const onSubmit = async (e: React.MouseEvent): Promise<void> => {
        e.preventDefault();
        const inputUserEmail = document.querySelector('input[name="Email"]') as HTMLInputElement;
        const inputName = document.querySelector('input[name="Name"]') as HTMLInputElement;
        const inputUserName = document.querySelector('input[name="UserName"]') as HTMLInputElement;
        const inputUserPassword = document.querySelector('input[name="Password"]') as HTMLInputElement;

        try {
            await registerNewUser({ email: inputUserEmail.value, name: inputName.value, userName: inputUserName.value, password: inputUserPassword.value });
            setIsRegisterSent(true);
        } catch (Error) {
            console.log(Error);
        }
    };

    const onHasAccount = (e: React.MouseEvent): void => {
        e.preventDefault();
        setRegistration(false);
    };

    if (!isRegisterSent) {
        return (
            <div className="Auth-content">
                <label className="Hello-label">registration</label>
                <label className="Text-label" htmlFor="Email">Email</label>
                <input className="Input-auth" placeholder="email" name="Email"></input>
                <label className="Text-label" htmlFor="Name">Name or Nick</label>
                <input className="Input-auth" placeholder="name or nick" name="Name"></input>
                <label className="Text-label" htmlFor="UserName">UserName</label>
                <input className="Input-auth" placeholder="user name" name="UserName"></input>
                <label className="Text-label" htmlFor="Password">Password</label>
                <input className="Input-auth" placeholder="password" name="Password"></input>
                <div className="Submit-div">
                    <button onClick={onSubmit}>Submit</button>
                </div>
                <div className="Message-div" onClick={onHasAccount}>
                    <span className="Message-span">Back to log In from.</span>
                </div>
            </div>
        );
    }
    else {
        return (
            <div className="Auth-content Border-top">
                <span className="Message-span-ver">Verification Message was sent to you.<br />Please check your Email.</span>
                <div className="Message-div Border-top" onClick={onHasAccount}>
                    <span className="Message-span">Back to log In from.</span>
                </div>
            </div>
        );
    }
}
export default Registration;