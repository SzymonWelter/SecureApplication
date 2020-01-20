import React from "react";
import { history } from "helpers";
import { Router, Switch, Route, Redirect } from "react-router-dom";
import { Home, SignIn, SignUp, Public } from "pages";
import { PrivateRoute } from "routing";

function App() {
  return (
      <Router history={history}>
        <Switch>
          <Route path='/public' component={Public} />
          <PrivateRoute exact path="/" component={Home} />
          <Route path="/signin" component={SignIn} />
          <Route path="/signup" component={SignUp} />
          <Route path='*' exact={true}>
            <Redirect to='/' />
          </Route>
        </Switch>
      </Router>
  );
}

export default App;
