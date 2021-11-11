
function cadastroUser() {
    var url = "https://localhost:44353/CadastroUsuario/";
    var data = {};
    data.email = document.querySelector('input[name=email]');
    data.senha = document.querySelector('input[name=senha]');
    data.nome = document.querySelector('input[name=nome]');
    data.sobrenome = document.querySelector('input[name=sobrenome]');
    data.idade = document.querySelector('input[name=idade]');
    data.celular = document.querySelector('input[name=celular]');
    data.cidade = document.querySelector('input[name=cidade]');
    data.estado = document.querySelector('input[name=estado]');

    var json = JSON.stringify(data);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onload = function () {
        console.log(xhr.responseText);
    }
    xhr.send(json);

}



