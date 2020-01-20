import React from "react";
const Loading = props => (
  <div className="loading-wrapper">
    {props.loading && <div className="spinner-grow"></div>}
  </div>
);

export default Loading;