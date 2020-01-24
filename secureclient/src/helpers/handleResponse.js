export default function handleResponse(response) {
  if (!response.ok) {
    if ([401, 403].indexOf(response.status) !== -1) {
      return {
          logout: true
      }
    }

    const error = (response.data && response.data.message) || response.statusText;
    return Promise.reject(error);
  }
  return response;
}