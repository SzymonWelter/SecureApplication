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
    name: 'isPublic',
    type: 'checkbox',
    class: 'width-auto'
  }
  return (
    <div className="center-child">
      <form className="note-form" id="note-area" onSubmit={props.onSubmit}>
        <InputArea model={inputModel} />
        <div>
          <textarea form="note-area" className="note-form__text-area" name='text' />
        </div>
        <InputArea model={checkboxModel} class='align-right'/>
        <InputArea model={submitModel} class='align-center'/>
      </form>
    </div>
  );
}
export default NoteArea;
