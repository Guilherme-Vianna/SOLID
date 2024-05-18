// Liskov Principle of Substitution
// Esse principio diz que toda classe que for derivada de uma classe pai, deve ser capaz de usar a classe pai sem quebrar o programa.
// 3. Responsável por verificar situacao de emprestimo


//Exemplo Incorreto 
public class Account {
    public decimal Saldo { private get; private set; } // Deixei como privado para que eu possa manipular o saldo apenas dentro da classe usando os metodos
    public decimal GetSaldo() {
        return Saldo;
    }
    
    public bool ConsultarEmprestimo() { 
        //Verifica condicoes de transferencia
        return true; 
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

public class AccountKids : Account{ 

    public void MostrarDados() { 
        ConsultarEmprestimo(); 
    }
    // Aqui eu estou chamando um metodo que nao tem nada a ver com a classe AccountKids, ou seja, estou quebrando o principio do SOLID. 
    // Ja que a classe Account Kids nao tem nada a ver com emprestimos. 
}

// Para resolver isso eu preciso mudar a minha abstracao


// Exemplo Correto
public class Account {
    public decimal Saldo { private get; private set; } // Deixei como privado para que eu possa manipular o saldo apenas dentro da classe usando os metodos
    public decimal GetSaldo() {
        return Saldo;
    }
    public decimal SetSaldo(value decimal) {
        Saldo = value;
    }
}


public class AccountAdult : Account { 
    public bool ConsultarEmprestimo() { 
        //Verifica condicoes de transferencia
        return true; 
    }
}

public class AccountKids : Account{ 
    // Agora a classe kids nao tem um exemplo de emprestimo, ou seja, eu nao estou quebrando o principio do SOLID
}