import React from "react";
import InputArea from "./InputArea";
function NoteArea(props) {
  const inputModel = {
    title: "title",
    name: "title",
    class: 'align-left'
  };
  const submitModel = {
      value: 'ADD',
      type: 'submit',
      class: 'form-input--submit'
  }

  const checkboxModel = {
    title: 'Public',
    type: 'checkbox',
    class: 'width-auto'
  }
  return (
    <div className="center-child">
      <form className="note-form" id="note-area">
        <InputArea model={inputModel} />
        <div>
          <textarea form="notearea" className="note-form__text-area"/>
        </div>
        <InputArea model={checkboxModel} class='align-right'/>
        <InputArea model={submitModel} class='align-center'/>
      </form>
    </div>
  );
}
export default NoteArea;
