
function cadastroUser1() {

    var data = {};
    data.Email = document.querySelector('input[name=email]');
    data.Senha = document.querySelector('input[name=senha]');
    data.Nome = document.querySelector('input[name=nome]');
    data.Sobrenome = document.querySelector('input[name=sobrenome]');
    data.Idade = document.querySelector('input[name=idade]');
    data.Celular = document.querySelector('input[name=celular]');
    data.Cidade = document.querySelector('input[name=cidade]');
    data.Estado = document.querySelector('input[name=estado]');

    fetch("https://localhost:44353/CadastroUsuario/", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
        .then((response) => response.json())
        .then((data) => {
            console.log("Success:", data);
        })
        .catch((error) => {
            console.error("Error:", error);
        });


    $(document).ready(function () {
        // aqui vai seu código já criado

        $("#click").on("click", function () { // Quando o elemento do id "click" é clicado...
            var id_cart = $("#produtos_id").val(); // Pega o valor do campo produtos_id
            var total_venda = $(".total_venda").text(); // Pega o total

            $.ajax({
                method: "POST",
                url: "servidor.php",
                data: { idCart: id_cart, totalVenda: total_venda } // Dados a serem enviados
            });
        });
    });

}












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



