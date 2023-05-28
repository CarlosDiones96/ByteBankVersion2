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