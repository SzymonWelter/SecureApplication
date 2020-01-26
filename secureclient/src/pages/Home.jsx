import React, { useState, useEffect } from "react";
import { List, NoteArea } from "components";
import { authService, notesService } from "services";
function Home(props) {
  const [state, setState] = useState({ notes: [] });

  const updateList = () => {
    notesService
      .getUserNotes()
      .then(items => setState({ notes: items }))
      .catch(error => setState({ error: error }));
  };

  useEffect(() => {
    updateList();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const onSubmit = e => {
    e.preventDefault();
    setState({ loading: true });
    addNote(e.target)
      .then(result => setState({ loading: false, message: result.message }))
      .catch(error => setState({ loading: false, error: error }))
      .then(() => updateList());
  };

  const logout = () => {
    authService.logout().then(() => {
      props.history.push("/signin");
    });
  };

  return (
    <div className="page-wrapper">
      <div className="header">
        <button className="button" onClick={logout}>
          Log out
        </button>
      </div>
      <NoteArea onSubmit={onSubmit} />
      <div className="center-child">
        <label className="error">{state.error}</label>
        <label className="success">{state.message}</label>
      </div>
      <div className="center-child">
        <List items={state.notes} />
      </div>
    </div>
  );
}

function addNote(form) {
  const noteModel = new FormData();
  noteModel.append("title", form.title.value);
  noteModel.append("text", form.text.value);
  noteModel.append("isPublic", form.isPublic.checked);
  return notesService.addNote(noteModel);
}

export default Home;
