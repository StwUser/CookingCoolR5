import React from "react";
import "./ContentForm.css";
import { IUser } from '../../services/Interfaces';
import Navigation from '../navigation/Navigation';

interface IContentFormData {
    user: IUser
}

function ContentForm( { user }: IContentFormData): JSX.Element {

    const token = user.accessToken as string;

    return (
        <div className="Content-form">
            <Navigation token={token} />
            <div className="2">CONTENT</div>
        </div>
    );
}
export default ContentForm;