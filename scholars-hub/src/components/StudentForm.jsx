import React, { useState, useEffect } from "react";
import { createStudent, updateStudent, getStudentById } from "../api";

const StudentForm = ({ studentId, onSuccess }) => {
  const [student, setStudent] = useState({
    id: "",
    name: "",
    age: "",
    email: "",
  });

  useEffect(() => {
    if (studentId) {
      const fetchStudent = async () => {
        const data = await getStudentById(studentId);
        setStudent(data);
      };
      fetchStudent();
    }
  }, [studentId]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setStudent((prevStudent) => ({ ...prevStudent, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (studentId) {
      await updateStudent(student);
    } else {
      await createStudent(student);
    }
    onSuccess();
  };
  return (
    <form onSubmit={handleSubmit} className="form-container">
      <input
        type="text"
        name="name"
        className="input-form"
        value={student.name}
        onChange={handleChange}
        placeholder="Enter your name"
        required
      />
      <input
        type="number"
        name="age"
        className="input-form"
        value={student.age}
        onChange={handleChange}
        placeholder="Enter your age"
        required
      />
      <input
        type="email"
        name="email"
        className="input-form"
        value={student.email}
        onChange={handleChange}
        placeholder="Enter your email"
        required
      />
      <button type="submit" id="submit-button">{studentId ? 'Update' : 'Add'}</button>
    </form>
  );
};

export default StudentForm;
