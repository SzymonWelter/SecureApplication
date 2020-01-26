import React, { useState } from "react";
import { Form } from "components";
import { authService } from "services";
import { signInFormModel } from "models";
import { Link } from "react-router-dom";
import { HeaderButton } from "components";

function SignIn(props) {
  const [state, setState] = useState({
    loading: false,
    error: ""
  });

  const submitHandler = e => {
    setState({ loading: true });
    signin(e)
      .then(() => {
        setState({ loading: false });
      })
      .then(() => {
        props.history.push("/");
      })
      .catch(error => {
        setState({ error: error.message, loading: false });
      });
  };

  return (
    <div className="center-child page-wrapper">
      <HeaderButton link={"/public"} name="Public notes" />
      <section className="signin-section">
        <Form
          title="Sign in"
          inputs={signInFormModel}
          onSubmit={submitHandler}
          loading={state.loading}
          error={state.error}
        />
        <div className="center-child">or</div>
        <div className="center-child">
          <Link to="/signup" className="link">
            Sign up
          </Link>
        </div>
      </section>
    </div>
  );
}

async function signin(event) {
  event.preventDefault();
  const signInModel = new FormData();
  signInModel.append("username", event.target.username.value);
  signInModel.append("password", event.target.password.value);
  return await authService.authenticate(signInModel);
}

export default SignIn;
