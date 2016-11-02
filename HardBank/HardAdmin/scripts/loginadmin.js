
$(document).ready(function () {
    $('#submitLogin').click(function () {
        submit();
    });
});



function submit() {
    var postData = JSON.stringify({
        "username": $('#inputBrukerId').val(),
        "password": $('#inputPassord').val()
    });

    $.ajax({
        type: "POST",
        url: "Admin/Login",
        data: postData,
        contentType: "application/json; charset=utf-8",
        success: function callbackfunction(result) {
            if (result == "True") {
                alert("Success");
            } else {
                $('#loginFailModal').modal('toggle');
            }
        }
    });
}




