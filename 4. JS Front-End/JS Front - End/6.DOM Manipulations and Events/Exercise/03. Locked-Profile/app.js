function lockedProfile() {
    const buttons = Array.from(document.querySelectorAll('.profile button'));

    buttons.forEach(button => {
        button.addEventListener('click', () => {
            const profile = button.parentNode;
            const isLocked = profile.querySelector('input[type="radio"]:checked').value === 'lock';
            const hiddenDiv = profile.querySelector('div');

            if (!isLocked) {
                if (button.textContent === 'Show more') {
                    hiddenDiv.style.display = "block";
                    button.textContent = "Hide it";
                } else {
                    hiddenDiv.style.display = 'none';
                    button.textContent = 'Show more';
                }
            } 
        })   
    }); 
}