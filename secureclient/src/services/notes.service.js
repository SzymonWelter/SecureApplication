import { requestService } from "./requests.service";
import { cookieService } from "./cookie.service";

function getPublicNotes() {
  return requestService.get("public/notes");
}

function getUserNotes() {
  const userId = cookieService.getValueOfCookie("user");
  return requestService
    .get(`${userId}/notes`)
    .then(response => response.json());
}

function addNote(data) {
  const userId = cookieService.getValueOfCookie("user");
  return requestService
    .post(`${userId}/notes`, data)
    .then(response => response.json())
    .then(result => {
        if(!result.isSuccess){
            throw Error(result.message);
        }
        return result;
    });
}

function removeNote() {
  requestService.del();
}

export const notesService = {
  getPublicNotes,
  getUserNotes,
  addNote,
  removeNote
};
