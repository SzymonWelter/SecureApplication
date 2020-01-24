import React from "react";

function Element(props) {
  return (
    <div className="list-element">
      <h3 className="list-element__title">{props.title}</h3>
      <div className="list-element__text">
        {props.text}
      </div>
      { props.private &&
        <button id={props.id} className='list-element__remove-button'>Remove</button>
      }
    </div>
  );
}

export default Element;