function SubmitButtonDisable(){
    const submitButton = document.getElementById("SubmitButton");
    if (submitButton){
        submitButton.disabled = true;
        submitButton.style.background = "#D8D8D8";
        submitButton.parentElement.style.background = "#D8D8D8";
        submitButton.innerHTML = 'Submitting...';
    }
}

function LoginButtonEnable(){
    const submitButton = document.getElementById("SubmitButton");
    if (submitButton){
        submitButton.disabled = false;
        submitButton.style.background = "#5905D4";
        submitButton.parentElement.style.background = "#5905D4";
        submitButton.innerHTML = 'Log in';
    }
}