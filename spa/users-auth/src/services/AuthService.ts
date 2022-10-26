import https from '../http-common';


export async function login(login: any) {
    const response = await https.post(`/login`, login)
    return response.data;

}
export async function register(user: any) {
    const response = await https.post(`/login`, user)
    return response.data.users;

}


