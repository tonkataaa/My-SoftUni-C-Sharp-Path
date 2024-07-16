function attachEvents() {
    let loadBtn = document.querySelector('button#btnLoad');
    let createBtn = document.querySelector('button#btnCreate');
    let personField = document.querySelector('input#person');
    let phoneField = document.querySelector('input#phone');
    let phoneBookUl = document.querySelector('ul#phonebook');
    let tempUrl = 'http://localhost:3030/jsonstore/phonebook';

    loadBtn.addEventListener('click', function() {
        phoneBookUl.innerHTML = '';
        fetch(tempUrl)
            .then(response => response.json())
            .then(data => {
                Object.entries(data).forEach(([id, entry]) => {
                    let li = document.createElement('li');
                    let delBtn = document.createElement('button');

                    delBtn.textContent = 'Delete';
                    li.id = id;
                    let delUrl = `http://localhost:3030/jsonstore/phonebook/${li.id}`;
                    li.textContent = `${entry.person}: ${entry.phone} `;
                    li.appendChild(delBtn);

                    delBtn.addEventListener('click', function() {
                        fetch(delUrl, { method: 'DELETE' })
                            .then(() => {
                                li.remove(); 
                            })
                            .catch(err => console.error('Error deleting entry:', err));
                    });

                    phoneBookUl.appendChild(li);
                });
            })
            .catch(err => console.error('Error loading phonebook:', err));
    });

    createBtn.addEventListener('click', function() {
        let personInfo = personField.value;
        let phoneInfo = phoneField.value;
        if (personInfo === '' || phoneInfo === '') {
            return;
        }
        fetch(tempUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ person: personInfo, phone: phoneInfo })
        })
            .then(response => response.json())
            .then(() => {
                personField.value = '';
                phoneField.value = '';
                loadBtn.click(); 
            })
            .catch(err => console.error('Error creating entry:', err));
    });
}

attachEvents();
