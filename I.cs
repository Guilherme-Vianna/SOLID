// Principio da Segregacao de Interface
// Esse principio diz que toda classe que adicionar uma interface tem que ser capaz de implementar todos os metodos da interface corretamente 
// 4. Responsável por implementar funcoes de conta


// Exemplo Incorreto
// No nosso dominio nao podemos fazer transferencias internacionais em classes que nao sao CNPJ

public interface IAccount { 
    public void Transferencia(); 
    public void TransferenciaInternacional(); 
}

public class AdultAccount : IAccount { 
    public void Transferencia() { 
        // Faz transferencia
    }
    public void TransferenciaInternacional() { 
        throw new NotImplementedException(); // <--- Errado 
        // Nao faz transferencia internacional porque nao esta disponivel
    }
}

public class EnterpriceAccount : IAccount { 
    public void Transferencia() { 
        // Faz transferencia
    }
    public void TransferenciaInternacional() { 
        // Faz transferencia internacional
    }
}


// Exemplo Correto
// No nosso dominio nao podemos fazer transferencias internacionais em classes que nao sao CNPJ
// Para isso criamos uma interface nova para separar
public interface IAccount { 
    public void Transferencia(); 
}

public class AdultAccount : IAccount { 
    public void Transferencia() { 
        // Faz transferencia
    }
    public void TransferenciaInternacional() { 
        throw new NotImplementedException(); // <--- Errado 
        // Nao faz transferencia internacional porque nao esta disponivel
    }
}

public interface IAccountInternacional { 
    public void TransferenciaInternacional(); 
}

public class EnterpriceAccount : IAccount, IAccountInternacional { 
    public void Transferencia() { 
        // Faz transferencia
    }
    public void TransferenciaInternacional() { 
        // Faz transferencia internacional
    }
}