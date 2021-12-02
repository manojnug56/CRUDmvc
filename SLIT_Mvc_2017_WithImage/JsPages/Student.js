$(document).ready(function () {

    LoadTblDetails();

    function dateFormat(date) {
        var d = new Date(parseInt((date).match(/\d+/)));
        return ((d.getMonth() + 1) + "").padStart(2, "0")
            + "/" + (d.getDate() + "").padStart(2, "0")
            + "/" + d.getFullYear();
    }

    function LoadTblDetails() {



        $('#tbodydetails').html("");
        $('#tbodydetails1').html("");


        $.ajax({
            url: urlLoadTblDetails,
            type: "POST",
            data: {},
            dataType: 'json',
            success: function (data) {
                $(data).each(function (key, val) {
                    $('#tbodydetails')
                        .append('<tr>' +
                            '<td></td>' +
                            '<td style="display:none;">' + val.StudentID + '</td>' +
                            '<td style="text-align: center">' + val.FistName + '</td>' +
                            '<td style="text-align: center">' + val.LasttName + '</td>' +
                            '<td style="text-align: center">' + val.Nic + '</td>' +
                            '<td style="text-align: center">' + val.Gender + '</td>' +
                            //'<td style="display:none;">' + val.ImageFile + '</td>' +
                            '<td>' + '<span class="detailsdeletTr">' + '<span style="color:red;font-size: 20px;" class="fa fa-times deletSup">' + '</span>' + '</span>' + '</td>' +

                            '</tr>');



                    $('#tbodydetails1')
                        .append('<tr>' +
                            '<td></td>' +
                            '<td style="display:none;">' + val.StudentID + '</td>' +
                            '<td style="text-align: center">' + val.FistName + '</td>' +
                            '<td style="text-align: center">' + val.LasttName + '</td>' +
                            '<td style="text-align: center">' + val.Nic + '</td>' +
                            '<td style="text-align: center">' + val.Gender + '</td>' +
                            //'<td style="display:none;">' + val.ImageFile + '</td>' +
       

                            '</tr>');
                });
                $('#tabledetails').show();
                $('#tabledetails1').show();
            }
        });
    }

    $("#btnPrint").on('click', function () {
        printElement();
    });

    function printElement() {
        var domClone = $("#printableContent").html();

        var mywindow = window.open('');
        mywindow.height
        mywindow.document.write('<html><head>');
        //mywindow.document.write('<link rel="stylesheet" href="./css/print.css" type="text/css"/>');
        mywindow.document.write('</head><body>');
        mywindow.document.write(domClone);
        mywindow.document.write('</body></html>');
        mywindow.print();
        mywindow.close();
    }
});