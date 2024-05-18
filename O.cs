// Aberto a extensao e fechado a modificacao 
// Diz que toda classe tem que estar a aberta a uma extensao porem fechada a modificacao, ou seja, eu posso criar uma nova classe que herda da classe pai e adicionar novos metodos, porem eu nao posso modificar a classe pai.
// 2. Envia email


// Exemplo Incorreto 
public static class EmailSender {
    public bool SendEmail(string email) {
        // Envia email
        return true;
    }
}

// Eu modifico e fica isso 

public static class EmailSender {
    public bool SendEmail(string email, byte[] anexo) {
        // Envia email
        // Envia anexo
        return true;
    }
}

// Isso por si so nao daria problema porem se eu tivesse um metodo que usasse o SendEmail sem o anexo, eu teria que modificar o metodo para aceitar o anexo, e isso quebra o principio do SOLID.
// Para isso podemos adicionar um novo metodo a classe para enviar o anexo, ou criar uma nova classe que herda da classe pai e adicionar o metodo de envio de anexo.


// Exemplo Correto

public static class EmailSender {
    public bool SendEmail(string email) {
        // Envia email
        return true;
    }
    public bool SendEmailWithAnexo(string email, byte[] anexo) {
        // Envia email
        // Envia anexo
        return true;
    }
}

// Dessa forma nao quebramos o principio do SOLID, porem se eu tivesse que adicionar um novo metodo a classe pai, eu teria que criar uma nova classe que herda da classe pai e adicionar o novo metodo.

