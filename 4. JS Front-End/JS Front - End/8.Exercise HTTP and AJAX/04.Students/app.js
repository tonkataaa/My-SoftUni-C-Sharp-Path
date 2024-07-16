function attachEvents() {
  const url = `http://localhost:3030/jsonstore/collections/students`;

  const submitButton = document.getElementById('submit');
  const tbody = document.querySelector('#results tbody');

  submitButton.addEventListener('click', createStudent);

  loadStudents();
  function loadStudents() {
    fetch(url)
      .then((response) => response.json())
      .then((data) => {
        tbody.innerHTML = ''; 
        Object.values(data).forEach((student) => {
          const tr = document.createElement('tr');
          tr.innerHTML = `
            <td>${student.firstName}</td>
            <td>${student.lastName}</td>
            <td>${student.facultyNumber}</td>
            <td>${student.grade}</td>
          `;
          tbody.appendChild(tr);
        });
      })
      .catch((error) => console.error('Error:', error));
  }

  function createStudent() {
    const firstName = document.querySelector('input[name="firstName"]').value;
    const lastName = document.querySelector('input[name="lastName"]').value;
    const facultyNumber = document.querySelector('input[name="facultyNumber"]').value;
    const grade = document.querySelector('input[name="grade"]').value;

    // Validate inputs
    if (!firstName || !lastName || !facultyNumber || isNaN(grade) || !grade) {
      alert('Please fill in all fields correctly.');
      return;
    }

    const newStudent = {
      firstName,
      lastName,
      facultyNumber,
      grade: Number(grade),
    };

    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newStudent),
    })
      .then((response) => response.json())
      .then(() => {
        loadStudents();
        clearForm(); 
      })
      .catch((error) => console.error('Error:', error));
  }

  function clearForm() {
    document.querySelector('input[name="firstName"]').value = '';
    document.querySelector('input[name="lastName"]').value = '';
    document.querySelector('input[name="facultyNumber"]').value = '';
    document.querySelector('input[name="grade"]').value = '';
  }
}

attachEvents();
