export const cookieService = {
    setCookie,
    getValueOfCookie,
    removeCookie,
}

function setCookie(name, value, expiration){
    document.cookie = name + "=" + value + ";path=/;expires=" + expiration.toGMTString();
}

function getValueOfCookie(name){
    var cookie = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return cookie ? cookie[2] : null;
}

function removeCookie(name){
    document.cookie = name+'=; Max-Age=-99999999;';
}