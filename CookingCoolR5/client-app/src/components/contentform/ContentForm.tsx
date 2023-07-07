import React from "react";
import "./ContentForm.css";
import { IUser } from '../../services/Interfaces';
import GamesWithSales from '../gameswithsales/GamesWithSales';

interface IContentFormData {
    user: IUser
}

function ContentForm( { user }: IContentFormData): JSX.Element {

    const token = user.accessToken as string;

    return (
        <div className="Content-form">
            <GamesWithSales token={token} />
        </div>
    );
}
export default ContentForm;