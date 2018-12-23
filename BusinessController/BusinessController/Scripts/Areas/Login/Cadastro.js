var validado = true;

function validacao() {
    $('input[type="text"],input[type="email"],input[type="tel"]').css("border-color", "rgb(204, 204, 204)").css("box-shadow", "0px 0px white");
    var message = "<p>";

    if ($('#FIRSTNAME').val() == "") {
        validado = false;
        message += "Campo \"Nome\" é obrigatório!" + "<br/>";

        $('#FIRSTNAME').css("border-color","red");
        $('#FIRSTNAME').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#LASTNAME').val() == "") {
        validado = false;
        message += "Campo \"Sobrenome\" é obrigatório!" + "<br/>";

        $('#LASTNAME').css("border-color", "red");
        $('#LASTNAME').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#EMAIL').val() == "") {
        validado = false;
        message += "Campo \"E-mail\" é obrigatório!" + "<br/>";

        $('#EMAIL').css("border-color", "red");
        $('#EMAIL').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#NASCIMENTO').val() == "") {
        validado = false;
        message += "Campo \"Data de Nascimento\" é obrigatório!" + "<br/>";

        $('#NASCIMENTO').css("border-color", "red");
        $('#NASCIMENTO').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#MAE').val() == "") {
        validado = false;
        message += "Campo \"Nome da Mãe\" é obrigatório!" + "<br/>";

        $('#MAE').css("border-color", "red");
        $('#MAE').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#CPF').val() == "") {
        validado = false;
        message += "Campo \"CPF\" é obrigatório!" + "<br/>";

        $('#CPF').css("border-color", "red");
        $('#CPF').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#RG').val() == "") {
        validado = false;
        message += "Campo \"RG\" é obrigatório!" + "<br/>";

        $('#RG').css("border-color", "red");
        $('#RG').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#CELULAR').val() == "") {
        validado = false;
        message += "Campo \"Celular\" é obrigatório!" + "<br/>";

        $('#CELULAR').css("border-color", "red");
        $('#CELULAR').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#TELEFONE').val() == "") {
        validado = false;
        message += "Campo \"Telefone\" é obrigatório!" + "<br/>";

        $('#TELEFONE').css("border-color", "red");
        $('#TELEFONE').css("box-shadow", "0px 0px 10px red");
    }

    message += "</p>"

    if (!validado) {
        Message(message, 'warning');
    }

    return validado
}

$('#btn_save').click(function () {
    if (validacao()) {
        $.ajax({
            type: "POST",
            url: dirGravar,
            data: {
                firstName: $('#FIRSTNAME').val(),
                lastName: $('#LASTNAME').val(),
                email: $('#EMAIL').val(),
                nascimento: $('#NASCIMENTO').val(),
                mae: $('#MAE').val(),
                cpf: $('#CPF').val(),
                rg: $('#RG').val(),
                telefone: $('#TELEFONE').val(),
                celular: $('#CELULAR').val()
            },
            success: function (data) {
                Message(data.message, data.type);
            }
        });
    }
});