import axios from "axios";

const API_URL = 'https://localhost:7078';

export const getStudents = async () =>{
    const response = await axios.get(`${API_URL}/api/Student/GetAllStudents`);
    return response.data;
}

export const getStudentById = async (id)=>{
    const response = await axios.get(`${API_URL}/api/Student/GetStudentById/${id}`);
    return response.data;
}

export const createStudent = async (student)=>{
    const response = await axios.post(`${API_URL}/api/Student/CreateStudent`, student);
    return response.data;
}

export const updateStudent = async (student)=>{
    await axios.put(`${API_URL}/api/Student/UpdateStudent`, student);
}

export const deleteStudent = async (id) =>{
    await axios.delete(`${API_URL}/api/Student/DeleteStudent/${id}`); 
}