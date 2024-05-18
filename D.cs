// Principio da inversao de dependencia
// Esse principio fala que as classes tem que ser dependentes de interfaces e de abstracoes e nao de classes concretas
// Usando injecao de dependencia conseguimos fazer com que a classe seja dependente de uma interface e nao de uma classe concreta
// 5. Responsavel por consultar a cotacao

// Exemplo Incorreto
// Nesse caso criamos uma instancia da classe VerificadorDeCotacao dentro da classe Account

public class VerificadorDeCotacao { 
    public decimal ConsultarCotacao(string codigoMoeda) { 
        return 5.5m; 
    }
}

public class VisualizacaoDeGraficos { 
    public VerificadorDeCotacao _verificador;
    public VisualizacaoDeGraficos() { 
        _verificador = new VerificadorDeCotacao();
    }
    
    public VisualizarMoeda(string codigoMoeda) { 
        return _verificador.ConsultarCotacao(codigoMoeda);
    }
}

// Exemplo Correto
// Nesse caso criamos uma interface que o VerificadorDeCotacao implementa e usamos a interface dentro da classe account
// Dessa forma a classe account nao depende mais da classe concreta VerificadorDeCotacao e sim da interface IVerificadorDeCotacao
// Assim conseguimos alterar a classe VerificadorDeCotacao sem alterar a classe Account, e seguindo a base do SOLID podemos
// extender as funcionalidades adicionando novos metodos na interface. 

public interface IVerificadorDeCotacao { 
    public decimal ConsultarCotacao(string codigoMoeda);
}   

public class VerificadorDeCotacao : IVerificadorDeCotacao{ 
    public decimal ConsultarCotacao(string codigoMoeda) { 
        return 5.5m; 
    }
}

public class VisualizacaoDeGraficos { 
    public IVerificadorDeCotacao _verificador;
    public VisualizacaoDeGraficos(IVerificadorDeCotacao verificador) { 
        _verificador = verificador;
    }
    
    public VisualizarMoeda(string codigoMoeda) { 
        return _verificador.ConsultarCotacao(codigoMoeda);
    }
}