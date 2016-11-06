
$(document).ready(function () {
    $('#submitLogin').click(function (e) {
        e.preventDefault();
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
        contentType: "application/json; charset=utf-8"
    }).done(function (result) {
        if (result == "True") {
            var url = "/Admin/AdminSide";
            window.location.href = url;
        } else {
            $('#inputPassord').val('');
            $('#loginFailModal').modal("show");
        }
    });
}





