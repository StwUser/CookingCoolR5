import { AxiosInstance } from 'axios';
import axiosInstance from './Config/Axios.config';

abstract class HttpService {
    token: string = '';

    constructor(token: string) {
        this.token = token;
    }

    private readonly _api: AxiosInstance = axiosInstance(this.token);

    protected get API(): AxiosInstance {
        return this._api;
    }
}

export default HttpService;
