import ProjectHelper from '../Helpers/ProjectHelper';
import axios, { AxiosInstance, RawAxiosRequestHeaders, AxiosRequestConfig } from "axios";

let API_TOKEN = '';
let BASE_URL = ProjectHelper.isDevelopment ? 'http://localhost:15304/api/' : 'http://cookingcoolr5.somee.com/api/';

const setUpToken = (token: string): boolean => {

    API_TOKEN = token;
    return true;
}

const getHeaders = (): RawAxiosRequestHeaders => {
  
    return {
        "Authorization": `Bearer ${API_TOKEN}`,
        "Content-Type": 'application/json; charset=utf-8'
    };
};

const setRequestHeaders = (request: AxiosRequestConfig): void => {
    request.headers = getHeaders();
};

const getAxios = (token: string): AxiosInstance => {
    setUpToken(token);
    const axiosInstance = axios.create({ baseURL: BASE_URL });
    axiosInstance.interceptors.request.use(request => {
        setRequestHeaders(request);
        return request;
    });
  
    return axiosInstance;
};

export default getAxios;
