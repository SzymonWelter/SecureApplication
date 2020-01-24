import React from "react";
import { Link } from "react-router-dom";

function HeaderButton(props) {
  return (
    <div className="center-child">
      <Link to={props.link} className="link link--large">
        {props.name}
      </Link>
    </div>
  );
}

export default HeaderButton;
