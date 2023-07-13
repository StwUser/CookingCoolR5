import React from "react";
import "./Navigation.css";
import { NavLink } from "react-router-dom";

function Navigation() {

    return (
        <nav id="Nav-pan">
            <NavLink to="/" className={({ isActive }) => (isActive ? " Active-nav Nav-link" : "Nav-link")}>Log In</NavLink>
            <NavLink to="/GamesWithSales" className={({ isActive }) => (isActive ? " Active-nav Nav-link" : "Nav-link")}>GamesWithSales</NavLink>
        </nav>
    );
}
export default Navigation;