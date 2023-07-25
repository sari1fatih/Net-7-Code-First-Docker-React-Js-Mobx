import axios from 'axios';
// local http://localhost:5233/api
// docker http://localhost:44334/api
const api = axios.create({
    baseURL: 'http://localhost:44334/api'
});

api.interceptors.request.use(
    (config) => {
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

api.interceptors.response.use(
    (response) => {
        return response.data;
    },
    (error) => {
        return Promise.reject(error);
    }
);

 
const GET = async (url, data) => { 
    console.log('123 ',url)
    try { 
 
        const response = await api.get(url, { params: data })
       
        return response;
    }
    catch (err) {
        console.log('3213 ',url)
        return err.response;
    }
};

export default { GET };