import React, { Component } from "react";
import { Form, Header } from "components";
import { authService } from "services";
import { signUpFormModel } from "models";
import { Link } from "react-router-dom";

class SignUp extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: false,
      error: ""
    };
  }

  submitHandler = async event => {
    event.preventDefault();
    const signUpModel = {
      username: event.target.username.value,
      password: event.target.password.value,
      email: event.target.email.value
    };
    this.setState({ loading: true });
    try {
      await authService.signUp(signUpModel);
    } catch (error) {
      this.setState({ error: error.message });
    }
    this.setState({ loading: false });
  };

  render() {
    return (
      <div className="page-wrapper center-child">
        <Header link="/public" name='Public notes'/>
        <section className="signup-section">
          <Form
            title="Sign up"
            inputs={signUpFormModel}
            onSubmit={this.submitHandler}
            loading={this.state.loading}
            error={this.state.error}
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
}
export default SignUp;