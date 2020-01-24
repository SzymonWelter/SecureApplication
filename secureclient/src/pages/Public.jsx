import React, { useEffect } from "react";
import { HeaderButton, List } from "components";
import { notesService } from "services";
import { useState } from "react";
function Public(props) {

  const [state, setState] = useState({notes: []});
  useEffect(() => {
    notesService.getPublicNotes()
      .then(items => items.json())
      .then(items => setState({notes: items}));
      // eslint-disable-next-line react-hooks/exhaustive-deps
  },[])

  return (
    <div className="page-wrapper">
      <div className="center-child">
        <HeaderButton link="/signin" name="Sign in" />
        <List items={state.notes} />
      </div>
    </div>
  );
}
export default Public;
