var conprueba = 0;
$(function () {
    setInterval(Lecturas, 1000);
    setInterval(Bitacora, 1000);
    setInterval(estatus, 1000);
});


function Lecturas() {
    var htmltabla = '';
    var conModulo = 0;
    var conModulo1 = 0;
    $.ajax({
        type: "POST",
        url: "WSExzolt.asmx/OptenerLecturas",
        data: JSON.stringify({
            idBitacora: 7
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response.d, function (index, item) {

                if (item.DesModulo == "Contenedor 1" && conModulo==0) {
                    conModulo++;
                    htmltabla += '<tr class="">';
                    htmltabla += '<td>Contenedor 1</td>';
                    htmltabla += '<td></td>';
                    htmltabla += '<td></td>';
                    htmltabla += '<td></td>';
                    htmltabla += '<td></td>';
                    htmltabla += '</tr>';
                }

                if (item.DesModulo == "Contenedor verde" && conModulo1 == 0) {
                    conModulo1++;
                    htmltabla += '<tr class="">';
                    htmltabla += '<td>Contenedor 2</td>';
                    htmltabla += '<td></td>';
                    htmltabla += '<td></td>';
                    htmltabla += '<td></td>';
                    htmltabla += '<td></td>';
                    htmltabla += '</tr>';
                }

                

                htmltabla +='<tr class="success">';
                htmltabla += '<td>' + item.DesEtapa + '</td>';
                htmltabla += '<td>' + item.DesModulo + '</td>';
                htmltabla += '<td>' + item.DesSensor + '</td>';
                htmltabla += '<td aling="left">' + item.valor + '</td>';
                htmltabla += '<td>' + item.acronimo + '</td>';
                htmltabla += '</tr>';
            });
            $("#tbodyLecturas").html(htmltabla);
        },
    });

}

function Bitacora() {
    var htmltabla = '';
    $.ajax({
        type: "POST",
        url: "WSExzolt.asmx/OptenerBitacora",
        data: JSON.stringify({
            idBitacora: 7
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response.d, function (index, item) {

                console.log(item);

                htmltabla += '<tr class="success">';
                htmltabla += '<td>' + item.Proceso + '</td>';
                htmltabla += '<td>'+item.fechaInicio+'</td>';
                htmltabla += '<td>' + item.fechaFin + '</td>';
                htmltabla += '</tr>';

                //htmltabla += '<tr class="success">';
                //htmltabla += '<td>' + item.DesEtapa + '</td>';
                //htmltabla += '<td>' + item.DesModulo + '</td>';
                //htmltabla += '<td>' + item.DesSensor + '</td>';
                //htmltabla += '<td aling="left">' + item.valor + '</td>';
                //htmltabla += '<td>' + item.acronimo + '</td>';
                //htmltabla += '</tr>';
                

            });
            $("#tbodyBitacora").html(htmltabla);
        },
    });

}

function estatus() {
    console.log();
    conprueba++;

    if (conprueba >=1) {
        $("#etapa2").addClass("hidden")
        $("#etapa1").removeClass("hidden")       
    }
    if (conprueba >= 10) {
        $("#etapa1").addClass("hidden")
        $("#etapa2").removeClass("hidden")
    }
    if (conprueba >= 20) {
        $("#etapa1").addClass("hidden")
        $("#etapa1").addClass("hidden")
        conprueba = 0;
    }
    

    //$("#etapa2").removeClass("hidden")

}

