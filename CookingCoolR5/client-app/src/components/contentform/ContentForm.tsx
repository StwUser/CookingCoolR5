import React from "react";
import "./ContentForm.css";
import { IUser } from '../../services/AuthService';
import Navigation from '../navigation/Navigation';

interface IContentFormData {
    user: IUser
}

function ContentForm( { user }: IContentFormData): JSX.Element {


    return (
        <div className="Content-form">
            <Navigation />
            <div className="2">CONTENT</div>
        </div>
    );
}
export default ContentForm;