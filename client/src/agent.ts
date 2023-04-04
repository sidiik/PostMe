import axios, { AxiosResponse } from 'axios';
import { Post } from './types/PostTypes';

axios.defaults.baseURL = 'http://localhost:5000/api/v1';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) => axios.post<T>(url).then(responseBody),
  put: <T>(url: string, body: {}) => axios.get<T>(url).then(responseBody),
  delete: <T>(url: string) => axios.get<T>(url).then(responseBody),
};

const Posts = {
  all: requests.get<Post[]>('/posts'),
};

export const agents = {
  Posts,
};
