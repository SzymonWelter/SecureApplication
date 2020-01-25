export default function handleResponse(response) {
  if ([401, 403].indexOf(response.status) !== -1) {
    return {
      logout: true
    };
  }
  return response;
}
