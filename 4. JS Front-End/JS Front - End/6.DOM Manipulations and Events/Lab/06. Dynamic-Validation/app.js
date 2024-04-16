function validate() {
    const emailInput = document.getElementById("email");
    let regex = new RegExp('([a-z0-9]+@[a-z]+.[a-z]+)');

    emailInput.addEventListener('change', function(){
        if (regex.test(emailInput.value)) {
            emailInput.classList.remove('error');
        } else {
            emailInput.classList.add('error');
        }
    })
}