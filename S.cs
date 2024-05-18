// Reponsabilidade Unica 
// E a base do SOLID e diz que tudo deve ter rensabilidade unica. um metodo tem um unica responsabilidade, uma classe tem uma unica responsabilidade, um pacote tem uma unica responsabilidade, um projeto tem uma unica responsabilidade.
// 1. Responsável por verificar o saldo do cliente 


//Exemplo Incorreto 
// Nesse caso estou fazendo a transferencia de valores e verificando o saldo do cliente, ou seja, estou fazendo duas coisas em um unico metodo, o que é errado.
public class Account {
    public decimal Saldo { private get; private set; } // Deixei como privado para que eu possa manipular o saldo apenas dentro da classe usando os metodos
    public decimal GetSaldo() {
        return Saldo;
    }

    public decimal SetSaldo(value decimal) {
        Saldo = value;
    }

    public bool Transferir(Account contaOrigem, Account contaDestino, decimal valor) {
        if(contaOrigem.GetSaldo() >= valor) {
            contaOrigem.SetSaldo(contaOrigem.GetSaldo() - valor);
            contaDestino.SetSaldo(contaDestino.GetSaldo() + valor);
        }
    }
}



// Exemplo Correto 
// Nesse caso eu separei a verificação do saldo do cliente em um metodo e a transferencia de valores em outra classe, ou seja, cada metodo e classe tem uma unica responsabilidade.
public class Account {
    public decimal Saldo { private get; private set; } // Deixei como privado para que eu possa manipular o saldo apenas dentro da classe usando os metodos
    public decimal GetSaldo() {
        return Saldo;
    }
    public decimal SetSaldo(value decimal) {
        Saldo = value;
    }
}

public class Pix { 
    public bool Transferir(Account contaOrigem, Account contaDestino, decimal valor) {
        if(contaOrigem.GetSaldo() >= valor) {
            contaOrigem.SetSaldo(contaOrigem.GetSaldo() - valor);
            contaDestino.SetSaldo(contaDestino.GetSaldo() + valor);
        }
    }
}