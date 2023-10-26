document.getElementById('loginForm').style.display = 'none';
document.getElementById('registrationForm').style.display = 'block';
document.getElementById('toggleButton').innerText = 'Login';

function toggleForm() {
    var loginForm = document.getElementById('loginForm');
    var registrationForm = document.getElementById('registrationForm');
    var toggleButton = document.getElementById('toggleButton');
    if (loginForm.style.display === 'none') {
        loginForm.style.display = 'block';
        registrationForm.style.display = 'none';
        toggleButton.innerText = 'Register';
    } else {
        loginForm.style.display = 'none';
        registrationForm.style.display = 'block';
        toggleButton.innerText = 'Login';
    }
}

function onUserRegister() {
    document.getElementById('registrationForm').addEventListener('submit', function (e) {
        e.preventDefault();
    
        var username = document.getElementById('username').value;
        var email = document.getElementById('email').value;
        var password = document.getElementById('password').value;
        var confirmPassword = document.getElementById('confirmPassword').value;
    
        if (password !== confirmPassword) {
            document.getElementById('error').innerText = 'Passwords do not match.';
            return;
        }
    
        var data = {
            username: username,
            password: password,
            email: email
        };
    
        fetch('http://localhost:5052/registration', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log(data);
            mp.trigger('registerPlayer');
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
    });
}