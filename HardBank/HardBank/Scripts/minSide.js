$(document).ready(function () {
    $("#betalbtn").click(function () {
        var belop = document.getElementById("belop").value;
        var account = document.getElementById("tilKonto").value;

        var s = "Sikker på at du vil overføre " + belop + ",- til kontoen: " + account + "?";
        $("p#modalMessage").text(s);
    });
});