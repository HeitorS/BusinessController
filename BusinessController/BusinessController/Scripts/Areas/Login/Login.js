//Variáveis globais 
var validado = true;

//Função para validar os campos obrigatórios
function validacao() {
    $('input[type="text"],input[type="email"],input[type="tel"]').css("border-color", "rgb(204, 204, 204)").css("box-shadow", "0px 0px white");
    var message = "<p>";

    if ($('#USUARIO').val() == "") {
        validado = false;
        message += "Campo \"Usuário\" é obrigatório!" + "<br/>";

        $('#USUARIO').css("border-color", "red");
        $('#USUARIO').css("box-shadow", "0px 0px 10px red");
    }

    if ($('#SENHA').val() == "") {
        validado = false;
        message += "Campo \"Senha\" é obrigatório!" + "<br/>";

        $('#SENHA').css("border-color", "red");
        $('#SENHA').css("box-shadow", "0px 0px 10px red");
    }

    message += "</p>"

    if (!validado) {
        Message(message, 'warning');
    }

    return validado
}

//Função para o botão de logar
$('#btn_logar').click(function () {
    if (validacao()) {
        $.ajax({
            type: "POST",
            url: dirLogar,
            data: {
                usuario: $('#USUARIO').val(),
                senha: $('#SENHA').val()
            },
            success: function (data) {
                /************************************************************************************
                 * Quando retornar o tipo "information" significa que é o primeiro login do usuário *
                 * então ele irá mudar a senha para uma senha que siga os principios 
                 ************************************************************************************/
                if (data.type == "information") {
                    $('#trocaSenha').find('.modal-title').text(data.message);
                    $('#trocaSenha').find('.modal-body #senha').focus();
                    $('#trocaSenha').addClass('in');
                    $('#trocaSenha').css('display','block');
                }
                else
                    Message(data.message, data.type); 
            }
        });
    }
});

//Função para fechar o modal
$('#closeModal, .cloase').click(function () {
    $('#trocaSenha').removeClass('in');
    $('#trocaSenha').css('display', 'none');
});

//Função para salvar a alteração da Senha
$('#btn_msave').click(function () {
    $.ajax({
        type: "POST",
        url: dirTrocar,
        data: {
            usuario: $('#USUARIO').val(),
            senha: $('#senha').val(),
            confirmacao: $('#confirma').val()
        },
        success: function (data) {
            /************************************************************************************
            * Quando retornar o tipo "information" significa que é o primeiro login do usuário  *
            * então ele irá mudar a senha para uma senha que siga os principios                 *
            ************************************************************************************/

            if (data.type == "information") {
                $('#trocaSenha').find('.modal-title').text(data.message);
                $('#trocaSenha').find('.modal-body #senha').focus();
                $('#trocaSenha').addClass('in');
                $('#trocaSenha').css('display', 'block');
            }
            else if (data.type = "success") {
                $.ajax({
                    type: "POST",
                    url: dirTrocar
                });
            }
            else
                Message(data.message, data.type);
        }
    });
});