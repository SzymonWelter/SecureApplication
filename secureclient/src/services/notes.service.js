import { requestService } from "./requests.service"

function getPublicNotes(){
    return requestService.get('notes/public');
}

function getPrivateNotes(){
    requestService.get();
}

function addNote(){
    requestService.post();
}

function removeNote(){
    requestService.del();
}

export const notesService = {
    getPublicNotes,
    getPrivateNotes,
    addNote,
    removeNote
}