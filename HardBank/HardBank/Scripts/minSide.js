$(document).ready(function () {
    $("#betalbtn").click(function () {
        var belop = document.getElementById("belop").value;
        var account = document.getElementById("tilKonto").value;

        var s = "Sikker på at du vil overføre " + belop + ",- til kontoen: " + account + "?";
        $("p#modalMessage").text(s);
    });


    $("#datepicker").datepicker({
        firstDay: 1,
        minDate: 0,
        defaultDate:0
    });

    var switcher = 0;
    $('#toggle-on').click(function () {
        if (switcher == 0) {
            $('#dateField').collapse('show');
            switcher = 1;
        } else if (switcher == 1) {
            $('#dateField').collapse('hide');
            switcher = 0;
        }
    });

   
});

