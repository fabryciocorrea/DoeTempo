let nome = document.querySelector("#nome");
let senha = document.querySelector("#senha");
let email = document.querySelector("#email");
let sobrenome = document.querySelector("#sobrenome");
let idade = document.querySelector("#idade");
let celular = document.querySelector("#celular");
let cidade = document.querySelector("#cidade");
let estado = document.querySelector("#estado");
let form = document.querySelector("#form");

console.log(nome, senha, email, sobrenome, idade, celular, cidade, estado, form)

form.addEventListener("submit", (event) => {
    event.preventDefault();
    let data = {
        name: nome.value,
        job: email.value
    };

    
})

function cadastrar(data){
	return Promise.resolve(	
		fetch('https://localhost:44353/api/DataAccess/CadastroUsuario', {
        		method: 'POST',
        		body: JSON.stringify(data)
    		})
        	.then(res => res.json())
        	.then(res => console.log(res));)
}