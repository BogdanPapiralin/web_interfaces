document.querySelector("form").addEventListener('submit', function (event) {
 
  event.preventDefault()

  removeValidation()

  checkPasswordMatch()
})

var checkPasswordMatch = function () {
  password = document.getElementById("password");
  if (password.value.length<8){
    document.getElementById("password_error").style.display = "block";
  }
}
var removeValidation = function () {
  document.getElementById("password_error").style.display = "none";
}