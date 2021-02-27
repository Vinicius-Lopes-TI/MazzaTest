function LogarSistema() {
    debugger;
    if ($("#username").val() == "") {
        alert("Email Obrigatório");
        return;
    }
    if ($("#password").val() == "") {
        alert("Senha obrigatória");
        return;
    }

    var data = {
        "usuario": $("#username").val(),
        "senha": $("#password").val(),
    };

    $.ajax({
        url: urlObterAutenticacao,
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",        
        success: function (data) {
            debugger;
            if (data.sucesso) {
                window.location.href = urlPaginaInicial
            }
            else if (!data.sucesso) {
                alert(data.msg);
            }
        },
        error: function () {
            alert("Erro")
        }
    });
}