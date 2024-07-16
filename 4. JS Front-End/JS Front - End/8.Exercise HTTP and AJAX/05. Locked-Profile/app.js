async function lockedProfile() {
    const main = document.getElementById('main');
    main.innerHTML = '';  

    const response = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
    const data = await response.json();

    const createProfileCard = (profile, index) => {
        const profileDiv = document.createElement('div');
        profileDiv.className = 'profile';
        profileDiv.innerHTML = `
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user${index}Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user${index}Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user${index}Username" value="${profile.username}" disabled readonly />
            <div class="user${index}HiddenInfo" style="display: none;">
                <hr>
                <label>Email:</label>
                <input type="email" name="user${index}Email" value="${profile.email}" disabled readonly />
                <label>Age:</label>
                <input type="text" name="user${index}Age" value="${profile.age}" disabled readonly />
            </div>
            <button>Show more</button>
        `;

        // Add event listener to the button
        const button = profileDiv.querySelector('button');
        button.addEventListener('click', () => {
            const hiddenInfo = profileDiv.querySelector(`.user${index}HiddenInfo`);
            const isLocked = profileDiv.querySelector(`input[name="user${index}Locked"][value="lock"]`).checked;

            if (!isLocked) {
                if (hiddenInfo.style.display === 'none') {
                    hiddenInfo.style.display = 'block';
                    button.textContent = 'Hide it';
                } else {
                    hiddenInfo.style.display = 'none';
                    button.textContent = 'Show more';
                }
            }
        });

       
        main.appendChild(profileDiv);
    };

    Object.values(data).forEach((profile, index) => {
        createProfileCard(profile, index + 1);
    });
}
