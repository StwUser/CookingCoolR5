import React from "react";
import "./Authorization.css";
import { authService, IUser, IAuth } from '../../services/AuthService';

interface IAuthorization {
    setUser: Function,
    setRegistration: Function
}

function Authorization({ setUser, setRegistration }: IAuthorization): JSX.Element {

    const getUser = async (query: IAuth): Promise<IUser> => {
        const res = await authService.getToken(query);
        return res as IUser;
    }

    const fetchUser = async (query: IAuth): Promise<void> => {
        const result = await getUser(query);
        setUser(result);
    };

    const onSubmit = async (e: React.MouseEvent): Promise<void> => {
        e.preventDefault();
        const inputUserName = document.querySelector('input[name="UserName"]') as HTMLInputElement;
        const inputUserPassword = document.querySelector('input[name="Password"]') as HTMLInputElement;

        try {
            await fetchUser({ username: inputUserName.value, password: inputUserPassword.value });
        }
        catch (Error) {
            console.log(Error);
        }
    };

    const onRegistration = (e: React.MouseEvent): void => {
        e.preventDefault();
        setRegistration(true);
    };

    return (
        <div className="Auth-content">
            <label className="Hello-label">authorization</label>
            <label className="Text-label" htmlFor="UserName">UserName</label>
            <input className="Input-auth" placeholder="login" name="UserName"></input>
            <label className="Text-label" htmlFor="Password">Password</label>
            <input className="Input-auth" placeholder="password" name="Password" type="password"></input>
            <div className="Submit-div">
                <button onClick={onSubmit}>Submit</button>
            </div>
            <div className="Message-div" onClick={onRegistration}>
                <span className="Message-span">If you still don't have account, click for registration.</span>
            </div>
        </div>
    );
}
export default Authorization;