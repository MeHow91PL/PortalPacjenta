/// <reference path="jquery-3.1.1.js" />

$(document).ready(function () {

    var $resetBtnRejestracja = $("#resetBtnRejestracja");

    $resetBtnRejestracja.click(function () {
        $(".form-control").each(function () {
            $(this).val("");
        });
    });

});
