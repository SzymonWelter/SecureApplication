import React from "react";
import { Link } from "react-router-dom";

function Header(props) {
  return (
    <Link to={props.link} className="link link--sticky link--large">
      {props.name}
    </Link>
  );
}

export default Header;
