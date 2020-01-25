import { BehaviorSubject } from "rxjs";
import { cookieService } from "./cookie.service";
import { requestService } from "./requests.service";

const currentUserSubject = new BehaviorSubject({
  user: cookieService.getValueOfCookie("user")
});
function authenticate(signInModel) {
  return requestService.post("auth/authenticate", signInModel).then(() => {
    currentUserSubject.next({ user: cookieService.getValueOfCookie("user") });
  });
}

function signUp(signUpModel) {
  return requestService
    .post("users", signUpModel)
    .then(response => response.json())
    .then(result => {
      if (NotSuccess(result)) {
        throw Error(result.message);
      }
    });
}

function NotSuccess(result) {
  return !result.isSuccess;
}

function logout() {
  return requestService.post("auth/logout");
}

export const authService = {
  signUp,
  authenticate,
  logout,
  currentUser: currentUserSubject.asObservable(),
  get currentUserValue() {
    return currentUserSubject.value;
  }
};
