﻿$("#knapp").click(function () {
    if ($("#authkode").is(":empty")) {
        $("#authkode").val(0);
    }
    $("#authBox").addClass("hidden");
    $("#passBox").removeClass("hidden");
    $(this).replaceWith("<button  type='submit' id='knapp' class='btn btn-primary'><i class='fa fa-adjust fa-arrow-right' aria-hidden='true'></i></button>");
});