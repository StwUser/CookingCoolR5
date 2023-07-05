import React from "react";
import "./ContentForm.css";
import { authService, IUser, IAuth } from '../../services/AuthService';

interface IContentFormData {
    user: IUser
}

function ContentForm( { user }: IContentFormData): JSX.Element {


    return (
        <div className="Content-form">
            <div className="Content-row-header">
                <div>1</div><div>2</div><div>3</div><div>4</div><div>5</div>
            </div>
            <div className="Content-row-content">

            </div>
        </div>
    );
}
export default ContentForm;