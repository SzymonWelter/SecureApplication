import React from "react";
function InputArea(props) {
  return (
    <div className={`form__input-area ${props.class ? props.class : ""}`}>
      <label className="form-input__name">{props.model.title}</label>
      <input
        className={`form-input ${props.model.class} ${
          props.disabled ? `form-input--disabled` : ""
        }`}
        type={props.model.type}
        name={props.model.name}
        value={props.model.value}
        disabled={props.disabled}
        onChange={props.onChange}
      />
    </div>
  );
}

export default InputArea;
