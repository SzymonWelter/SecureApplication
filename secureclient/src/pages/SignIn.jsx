import React, { Component } from "react";
import { Form } from "components";
import { authService } from "services";
import { signInFormModel } from "models";
import { Link } from "react-router-dom";
import { Header } from "components";

class SignIn extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: false,
      error: ""
    };
  }

  submitHandler = async event => {
    event.preventDefault();
    const signInModel = {
      username: event.target.username.value,
      password: event.target.password.value
    };
    this.setState({ loading: true });
    try {
      await authService.authenticate(signInModel);
    } catch (error) {
      this.setState({ error: error.message });
    }
    this.setState({ loading: false });
  };

  render() {
    return (
      <div className="page-wrapper center-child">
        <Header link={'/public'} name='Public notes'/>
        <section className="signin-section">
          <Form
            title="Sign in"
            inputs={signInFormModel}
            onSubmit={this.submitHandler}
            loading={this.state.loading}
            error={this.state.error}
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
}
export default SignIn;