import React from "react";
import "./Navigation.css";
import { authService, IUser, IAuth } from '../../services/AuthService';

function Navigation(): JSX.Element {

    return (
        <div className="Content-row-header">
            <div className="Nav-item">1</div>
            <div className="Nav-item">2</div>
            <div className="Nav-item">3</div>
            <div className="Nav-item">4</div>
            <div className="Nav-item">5</div>
        </div>
    );
}
export default Navigation;