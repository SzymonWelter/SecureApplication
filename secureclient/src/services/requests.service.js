import { handleResponse } from "helpers";
import { authService } from "./auth.service";
import { config } from "helpers";

export const requestService = {
  get,
  post,
  put,
  del
};

function get(path, query = {}, headers = {}) {
  path += formatQuery(query);
  return request(path, "GET", {}, headers);
}

function post(path, body = {}, headers = {}) {
  return request(path, "POST", body, headers);
}

function put(path, body = {}, headers = {}) {
  return request(path, "PUT", body, headers);
}

function del(path, query = {}, headers = {}) {
  path += formatQuery(query);
  return request(path, "DELETE", {}, headers);
}

async function request(path, method, body, headers) {
  const options = getOptions(method, body, headers);
  const response = await fetch(`${config.endpoint}/${path}`, options);

  const result = await handleResponse(response);

  if (result.logout) {
    authService.logout();
    return;
  }

  return result;
}

function formatQuery(query) {
  if (Object.keys(query).length === 0) return "";

  query = Object.keys(query).map(key => `${key}=${query[key]}`);

  query = "?" + query.join("&");
  return query;
}

function getOptions(method, body, headers) {
  const options = {
    method: method,
    headers: headers
  };

  includeCredentials(options);
  appendBody(body, options);

  return options;
}

function appendBody(body, options) {
  if (Object.keys(body).length > 0 || Array.from(body).length > 0) {
    options.body = body;
  }
}

function includeCredentials(options) {
  options.credentials = "include";
}
