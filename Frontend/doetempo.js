
function cadastroUser1() {

    var data1 = {};
    data1.Email = document.querySelector('input[name=email]');
    data1.Senha = document.querySelector('input[name=senha]');
    data1.Nome = document.querySelector('input[name=nome]');
    data1.Sobrenome = document.querySelector('input[name=sobrenome]');
    data1.Idade = document.querySelector('input[name=idade]');
    data1.Celular = document.querySelector('input[name=celular]');
    data1.Cidade = document.querySelector('input[name=cidade]');
    data1.Estado = document.querySelector('input[name=estado]');

    fetch("https://localhost:44353/CadastroUsuario/", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data1),
    })
        .then((response) => response.json())
        .then((data1) => {
            console.log("Success:", data1);
        })
        .catch((error) => {
            console.error("Error:", error);
        });



}

$(document).ready(function () {
    // aqui vai seu código já criado
    $("#submit").on("click", function () { // Quando o elemento do id "click" é clicado...
        var id_cart = $("#produtos_id").val(); // Pega o valor do campo produtos_id
        var total_venda = $(".total_venda").text(); // Pega o total
        var data1 = {};
        data1.Email = document.querySelector('input[name=email]');
        data1.Senha = document.querySelector('input[name=senha]');
        data1.Nome = document.querySelector('input[name=nome]');
        data1.Sobrenome = document.querySelector('input[name=sobrenome]');
        data1.Idade = document.querySelector('input[name=idade]');
        data1.Celular = document.querySelector('input[name=celular]');
        data1.Cidade = document.querySelector('input[name=cidade]');
        data1.Estado = document.querySelector('input[name=estado]');
        $.ajax({
            method: "POST",
            url: "https://localhost:44353/CadastroUsuario/",
            data: json.stringify(data1) // Dados a serem enviados
        });
    });

});











function cadastroUser() {
    var url = "https://localhost:44353/CadastroUsuario/";


    var json = JSON.stringify(data);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onload = function () {
        var users = JSON.parse(xhr.responseText);
        if (xhr.readyState == 4 && xhr.status == "200") {
            console.table(users);
        } else {
            console.error(users);
        }
    }
    xhr.send(json);

}



