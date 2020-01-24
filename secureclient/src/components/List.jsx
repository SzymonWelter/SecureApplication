import React from "react";
import Element from "./Element";

function List(props) {

  return (
    <ul className='list'>
        <Element />
      {props.items &&
        props.items.map((v, i) => (
          <li key={i}>
            <Element
              id={v.id}
              title={v.title}
              text={v.text}
              private={!v.isPublic}
            />
          </li>
        ))}
    </ul>
  );
}

export default List;