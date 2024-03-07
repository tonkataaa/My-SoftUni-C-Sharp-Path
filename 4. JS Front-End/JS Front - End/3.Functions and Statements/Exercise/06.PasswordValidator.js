function validatePassword(password) {
    let isOnlyLettersAndDigits = /^[a-zA-Z\d]+$/;
    let digitCount = (password.match(/\d/g) || []).length;

    if (password.length < 6 || password.length > 10) {
        console.log("Password must be between 6 and 10 characters");
    } else if (!isOnlyLettersAndDigits.test(password)) {
        console.log("Password must consist only of letters and digits");
    } else if (digitCount < 2) {
        console.log("Password must have at least 2 digits");
    } else {
        console.log("Password is valid");
    }
}

passValidator('logIn');
passValidator('MyPass123');
passValidator('Pa$s$s');