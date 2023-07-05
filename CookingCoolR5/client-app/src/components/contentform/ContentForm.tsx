import React from "react";
import "./ContentForm.css";
import { authService, IUser, IAuth } from '../../services/AuthService';
import Navigation from '../navigation/Navigation';

interface IContentFormData {
    user: IUser
}

function ContentForm( { user }: IContentFormData): JSX.Element {


    return (
        <div className="Content-form">
            <Navigation />
            <div className="Content-row-content">

            </div>
        </div>
    );
}
export default ContentForm;