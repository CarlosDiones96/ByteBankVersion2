# ByteBankVersion2
Este repositório foi utilizado para fins de estudos, tendo como exemplo o projeto ByteBank da trilha de C# da Alura. Por meio dele, aprendi e pratiquei conceitos fundamentais da programação orientada a objetos, como *abstração, herança, polimorfismo*, definição de *classes abstratas e interfaces*, além da utilização de *classes estáticas*. 
## Ferramentas
A implemtação foi feita em um projeto do tipo Console, diretamente no Visual Studio, com .NET 7.
## Divisão do sistema
O projeto foi dividido em 4 partes para facilitar a implementação do projeto:
1. Funcionarios
2. Parceria
3. SistemaInterno
4. Utilitario
### Funcionarios
A classe abstrata `Funcionario` serve de base para `Auxiliar`, `Designer` e `Diretor`.
A classe `Funcionario` definine os seguintes membros:

| Funcionario |
|:---------:|
| `Nome` |
| `Cpf` |
| `Salario` |
| `TotalDeFuncionarios` |
| `GetBonificacao()` |
| `AumentarSalario()`|


`FuncionarioAutenticavel` implementa a interface `IAutenticavel` (`SistemaInterno/IAutenticavel.cs`) que define o seguintes membros:
```C# 
 public interface IAutenticavel
    {
        public string Senha { get; set; }
        public bool Autenticar(string senha);
    }
```


### Parceria
`ParceiroComercial` é a única classe nesse nasmespace. Ela implementa `IAutenticavel`, pois precisa logar no sistema para usufruir das informações de que precisa.

```C#
 public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }

        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
```

### SistemaInterno
`SistemaInterno` e `IAutenticavel` são definidos nesse namespace. `SistemaInterno` define o método `Logar()` que espera dois argumentos: `funcionario` e `senha`.
```C#
public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario, string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (usuarioAutenticado)
            {
                Console.WriteLine("Seja bem-vindo(a)!");
                return true;
            }
            Console.WriteLine("Senha incorreta!");
            return false;
        }
    }
```

### Utilitario
Duas classes estão definidas nesse namespace: `GerenciadorDeBonficacao.cs` e `ExibicaoSistema.cs`. `GerenciadorDeBonificacao` tem a incumbência de registrar os tipos de deveriam de `Funcionario` por meio do método `Registrar(Funcionario funcionario)`.

```C#
public class GerenciadorDeBonificacao
    {
        public double TotalDeBonificacao { get; private set; }

        public void Registrar(Funcionario funcionario)
        {
            TotalDeBonificacao += funcionario.GetBonificacao();
        }
    }
```
Já a classe estática `ExibicaoSistema` serve apenas para exibir mensagens sobre os objetos criados no código cliente presentes em `Program.cs`:
```C#
public static class ExibicaoSistema
    {
        public static void MensgagemInicial()
        {
            Console.WriteLine("Bem-vindo(a) ao Sistema do ByteBank");
        }

        public static void MostrarNome(Funcionario funcionario)
        {
            Console.WriteLine($"Nome: {funcionario.Nome}");
        }
        //...
```
## Exemplo em Program.cs
A seguir, os objetos citados acima são criados em código cliente:
```C#
using ByteBankVersion2.Funcionarios;
using ByteBankVersion2.SistemaInterno;
using ByteBankVersion2.Utilitario;
using ByteBankVersion2.Parceria;

var diretor1 = new Diretor("y489894", 7000, "Carlos Cunha");

var designer1 = new Designer("7566456465", 3000, "Eduarda Monteiro");

var auxiliar1 = new Auxiliar("89347598", 2000, "Joaão Ferreira");

var parceiro1 = new ParceiroComercial();

ExibicaoSistema.MensgagemInicial();

ExibicaoSistema.MostrarNome(auxiliar1);
ExibicaoSistema.MostrarSalario(auxiliar1);
ExibicaoSistema.MostrarBonificacao(auxiliar1);

var gerenciador = new GerenciadorDeBonificacao();
gerenciador.Registrar(diretor1);
gerenciador.Registrar(designer1);
gerenciador.Registrar(auxiliar1);

Console.WriteLine($"\n\nTotal em bonificações: {gerenciador.TotalDeBonificacao}");
```
## Melhorias
Os sistema ainda está bastante simples. Validações e novas funcionalidades ainda faltam ser implementadas, por isso ainda não parece muito intuitivo. O próximo passo será a recriação desse sistema utilizado Windows Forms para que o usuário tenha uma melhor experiência.
