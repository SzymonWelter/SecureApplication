import React from "react";
import { Route, Redirect } from "react-router-dom";
import { authService } from "services";

export const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props => {
      const currentUser = authService.currentUserValue;
      if (!currentUser.user) {
        return (
          <Redirect
            to={{ pathname: "/signin", state: { from: props.location } }}
          />
        );
      }
      return <Component {...props} />;
    }}
  />
);
