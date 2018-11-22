function validacao() {
    $("#validaBody").validate({
        rules: {
            FIRSTNAME: { required: true, maxlength: 150 },
            LASTNAME: { required: true },
            EMAIL: { required: true }
        },
        messages: {
            nome: {
                required: "Nome é um campo obrigatório",
                maxlength: "Nome só pode conter 150 caracteres"
            },
            email: {
                required: "Sobrenome é um campo obrigatório"
            },
            mensagem: {
                required: "E-mail é um campo obrigatório"
            }
        }
    });
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
                noty({
                    text: data.message,
                    type: data.type,
                    layout: "bottomRight",
                    timeout: 4000,
                    closeWith: ["click", "houver"],
                    animation: {
                        open: 'animated bounceInRight',
                        close: 'animated bounceOutRight',
                        easing: 'swing',
                        speed: 500
                    }
                });
            },
            complete: function () {
                console.log("FOI");
            }
        });
    }
});