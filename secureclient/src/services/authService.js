import { BehaviorSubject } from "rxjs";
import { cookieService } from "./cookieService";

const currentUserSubject = new BehaviorSubject({
  user: cookieService.getValueOfCookie("currentUser")
});

function authenticate(signInModel) {
  console.log(signInModel);
}

function signUp(signUpModel) {
  console.log(signUpModel);
}

export const authService = {
  signUp,
  authenticate,
  currentUser: currentUserSubject.asObservable(),
  get currentUserValue() {
    return currentUserSubject.value;
  }
};
