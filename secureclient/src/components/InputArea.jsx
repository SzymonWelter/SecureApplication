import React from 'react';
function InputArea(props){
    return(<div className='form__input-area'>
    <label className='form-input__name'>{props.model.title}</label>
    <input className={`form-input ${props.model.class}`} type={props.model.type} name={props.model.name} value={props.model.value} disabled={props.disabled}/>
  </div>);
}

export default InputArea;