import React from "react";
import InputArea from './InputArea';
import Loading from './Loading';
import Error from './Error';
function Form(props) {
  return (
    <form className='form' onSubmit={props.onSubmit}>
      <h2 className="form__title">{props.title}</h2>
      {props.inputs.map((input, index) => (<InputArea key={index} model={input} disabled={props.loading}/>))}
      <Loading loading={props.loading}></Loading>
      <Error message={props.error}></Error>
    </form>
  );
}

export default Form;