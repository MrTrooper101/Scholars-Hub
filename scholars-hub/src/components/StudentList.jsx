import React, { useState, useEffect } from "react";
import { getStudents, deleteStudent } from "../api";
import StudentForm from "./StudentForm";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPenToSquare } from "@fortawesome/free-solid-svg-icons";
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import Modal from "./Model"; 

const StudentList = () => {
  const [students, setStudents] = useState([]);
  const [editingStudentId, setEditingStudentId] = useState(null);
  const [showModal, setShowModal] = useState(false);

  useEffect(() => {
    const fetchStudents = async () => {
      const data = await getStudents();
      setStudents(data);
    };
    fetchStudents();
  }, []);

  const handleEdit = (student) => {
    setEditingStudentId(student.id);
    setShowModal(true);
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
    setShowModal(false);
    const fetchStudents = async () => {
      const data = await getStudents();
      setStudents(data);
    };
    fetchStudents();
  };

  return (
    <div>
      <StudentForm studentId={editingStudentId} onSuccess={handleFormClose} />
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
                <button
                  className="icon-button"
                  onClick={() => handleEdit(student)}
                >
                  <FontAwesomeIcon icon={faPenToSquare} />
                </button>
                <button
                  className="icon-button"
                  onClick={() => handleDelete(student.id)}
                >
                  <FontAwesomeIcon icon={faTrash} />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <Modal show={showModal} onClose={handleFormClose}>
        <StudentForm studentId={editingStudentId} onSuccess={handleFormClose} />
      </Modal>
    </div>
  );
};

export default StudentList;
