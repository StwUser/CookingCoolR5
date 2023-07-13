import React from "react";
import "./Navigation.css";
import { NavLink } from "react-router-dom";

interface IAuthorization {
    setUser: Function,
    setRegistration: Function
}

function Navigation() {

    return (
        <nav>
            <NavLink to="/" className={({ isActive }) => (isActive ? " active" : "")}>Log In</NavLink>
            <NavLink to="/GamesWithSales" className={({ isActive }) => (isActive ? " active" : "")}>GamesWithSales</NavLink>
        </nav>
    );
}
export default Navigation;