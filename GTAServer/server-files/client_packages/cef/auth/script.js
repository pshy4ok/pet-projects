document.getElementById("registrationForm").style.display = "none";

function showRegistrationForm() {
  document.getElementById("loginForm").style.display = "none";
  document.getElementById("registrationForm").style.display = "block";
}

function showLoginForm() {
  document.getElementById("loginForm").style.display = "block";
  document.getElementById("registrationForm").style.display = "none";
}

function onUserRegister() {
  document.getElementById("registrationForm").addEventListener("click", function (e) {
    e.preventDefault();

    var username = document.getElementById("username").value;
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword").value;

    if (password !== confirmPassword) {
      document.getElementById("error").innerText = "Passwords do not match.";
      return;
    }

    var data = {
      username: username,
      password: password,
      email: email,
    };

    const regUrl = `${config.regApiUrl}`;
    fetch(regUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => {
        console.log(data);
        mp.trigger("closeWindow");
      })
      .catch((error) => {
        console.error("There was a problem with the fetch operation:", error);
      });
  });
}

function onUserLogin() {
    document.getElementById("loginForm").addEventListener("click", function (e) {
      e.preventDefault();
  
      var username = document.getElementById("loginUsername").value;
      var password = document.getElementById("loginPassword").value;
  
      var data = {
        username: username,
        password: password,
      };
  
      const logUrl = `${config.logApiUrl}`;
      fetch(logUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("Network response was not ok");
          }
          return response.json();
        })
        .then((data) => {
          console.log(data);
          mp.trigger("closeWindow");
        })
        .catch((error) => {
          console.error("There was a problem with the fetch operation:", error);
        });
    });
  }
