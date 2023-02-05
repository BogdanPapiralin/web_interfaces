document.querySelector("form").addEventListener('submit', function (event) {
 
  event.preventDefault()

  removeValidation()

  checkPasswordMatch()
})

var checkPasswordMatch = function () {
  password = document.getElementById("password");
  confirm_password =  document.getElementById("confirm_password");
  if (password.value != confirm_password.value) {
    document.getElementById("confirm_password_error").style.display = "block";
  }
  if (password.value.length<8){
    document.getElementById("password_error").style.display = "block";
  }
}
var removeValidation = function () {
  document.getElementById("confirm_password_error").style.display = "none";
  document.getElementById("password_error").style.display = "none";
}