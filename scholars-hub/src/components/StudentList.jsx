import React, { useState, useEffect } from "react";
import { getStudents, deleteStudent } from "../api";
import StudentForm from "./StudentForm";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPenToSquare } from '@fortawesome/free-solid-svg-icons'
import { faTrash } from '@fortawesome/free-solid-svg-icons'

const StudentList = () => {
  const [students, setStudents] = useState([]);
  const [editingStudentId, setEditingStudentId] = useState(null);

  useEffect(() => {
    const fetchStudents = async () => {
      const data = await getStudents();
      setStudents(data);
    };
    fetchStudents();
  }, []);

  const handleEdit = (student) => {
    setEditingStudentId(student.id);
  };

  const handleDelete = async (id) => {
    try {
      await deleteStudent(id);
      setStudents(students.filter((student) => student.id !== id));
    } catch (error) {
      console.error("Failed to delete student", error);
    }
  };

  const handleFormClose = () => {
    setEditingStudentId(null);
    const fetchStudents = async () => {
      const data = await getStudents();
      setStudents(data);
    };
    fetchStudents();
  };

  return (
    <div>
      <StudentForm studentId={editingStudentId} onSuccess={handleFormClose} />
      <div className="table-container">
        <h2>Student List</h2>
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Age</th>
              <th>Email</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {students.map((student) => (
              <tr key={student.id}>
                <td>{student.name}</td>
                <td>{student.age}</td>
                <td>{student.email}</td>
                <td>
                  <button onClick={() => handleEdit(student)}><FontAwesomeIcon icon={faPenToSquare} /></button>
                  <button onClick={() => handleDelete(student.id)}><FontAwesomeIcon icon={faTrash} /></button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default StudentList;
