/// <reference path="jquery-3.1.1.js" />

$(document).ready(function () {

    //Obsługa menu nawigacyjnego
    var sidebar = $("#sidebarPrzychodnia");
    var sidebar = $("#sidebarPrzychodnia");
    var $PrzychodniaBodyKontener = $('#PrzychodniaBodyKontener')
    var $wyswietlHistorie = $("#wyswietlHistorie");
    var $HistoriaWizyty = $("#HistoriaWizyty");


    $("#zwijaczMenu").click(function () {
        sidebar.toggleClass("sidebarZwiniety", 200);
        $("#PrzychodniaBodyKontener").toggleClass("przychodniaBodyKontenerRozwinięty");
        $(this).toggleClass("rotate");
    });



    $PrzychodniaBodyKontener.on('click', '.wyswietlHistorie', function (event) {//dzięki zastosowaniu takiej formy (delegat) zdarzenia działają również w elementach ładowanych przez AJAX
        alert("kliku kliku");
        //$("#HistoriaWizyty").css("display", "flex");
        $.ajax({
            url: '/HistoriaWizyt/pokazHistorie',
            type: 'POST',
            data: {
                idwizy: $(this).data("idwiz")
            },
            success: function (response) {
                $HistoriaWizyty.html(response);
                
            },
            error: function () {

                alert("Error pokaz historie");
            }
        });
    });

});