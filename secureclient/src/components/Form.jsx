import React from "react";
import InputArea from "./InputArea";
import Loading from "./Loading";
import Error from "./Error";
function Form(props) {
  return (
    <form className="form" onSubmit={props.onSubmit}>
      <Error message={props.error}></Error>

      <h2 className="form__title">{props.title}</h2>
      {props.inputs.map((input, index) => (
        <InputArea key={index} model={input} disabled={props.loading} onChange={props.onChange}/>
      ))}
      <Loading loading={props.loading}></Loading>
    </form>
  );
}

export default Form;
