import React, { useState } from "react";
import { Form, HeaderButton } from "components";
import { authService } from "services";
import { signUpFormModel } from "models";
import { Link } from "react-router-dom";

function SignUp(props) {
  const [state, setState] = useState({
    loading: false,
    error: ""
  });

  const submitHandler = e => {
    setState({ loading: true });
    signup(e)
      .then(() => {
        setState({ loading: false });
      })
      .then(() => {
        props.history.push("/signin");
      })
      .catch(error => {
        setState({ error: error.message, loading: false });
      });
  };

  const onChange = () => {
    setState({error: ''});
  };

  return (
    <div className="page-wrapper center-child">
      <HeaderButton link="/public" name="Public notes" />
      <section className="signup-section">
        <Form
          title="Sign up"
          inputs={signUpFormModel}
          onSubmit={submitHandler}
          loading={state.loading}
          error={state.error}
          onChange={onChange}
        />
        <div className="center-child">or</div>
        <div className="center-child">
          <Link to="/signin" className="link">
            Sign in
          </Link>
        </div>
      </section>
    </div>
  );
}

async function signup(event) {
  event.preventDefault();
  const signUpModel = new FormData();
  signUpModel.append("username", event.target.username.value);
  signUpModel.append("password", event.target.password.value);
  signUpModel.append("email", event.target.email.value);
  return await authService.signUp(signUpModel);
}

export default SignUp;
