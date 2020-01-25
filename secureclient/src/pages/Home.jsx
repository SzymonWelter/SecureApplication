import React from "react";
import { List, NoteArea } from "components";
import { authService } from "services";
function Home(props) {
  const logout = () => {
    authService
      .logout()
      .then(() => {
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
      <NoteArea />
      <div className="center-child">
        <List />
      </div>
    </div>
  );
}
export default Home;
