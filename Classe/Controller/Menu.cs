using System;
using System.Collections.Generic;
using FinancaDeMesa.Classe.Models;
using FinancaDeMesa.Classe.Util;

namespace FinancaDeMesa.Classe.Controller
{
    public static class Menu
    {

        #region Menus 
        /// <summary>
        /// Menu onde o usuario terá que inserir um dos valores abaixo : 
        /// 1 - Cadastrar-se (Metodo Cadastrar)  
        /// 2 - Logar (Metodo Logar)     
        /// 3 - Sair (Ignora o do while)  
        /// Qualquer outro valor sera ignorado  
        /// </summary>
        public static void Deslogado(){
            sbyte escolha = 0;
            do{
                Console.Clear();
                Console.WriteLine("O Que deseja fazer?\n1 - Se Cadastrar\n2 - Login\n3 - Sair");

                sbyte.TryParse(Console.ReadLine(),out escolha);
                switch (escolha)
                {
                    case 1:
                        CadastrarUsuario();
                        break;
                    case 2:
                        Logar();
                        if(Database.usuarioLogado != null)
                            Logado();
                        break;
                    case 3:
                        Design.MensagemChamativa("Até um outro dia!");
                        continue;                    
                    default:
                        Design.MensagemErro("Por favor escolha apenas uma das opções abaixo");
                        Console.ReadKey();
                        break;
                }
                Database.SalvarDatabase();
            }while(escolha != 3);
        }

        /// <summary>
        /// Menu onde o usuario deve inserir um dos valores abaixo :  
        /// 1 - Efetuar Transação     
        /// 2 - Mostrar Saldo   
        /// 3 - Mostrar Relatorio   
        /// 4 - Fazer logoff (MenuDeslogado)  
        /// </summary>
        public static void Logado(){
            Console.Clear();
            Design.MensagemChamativa($"Seja bem vindo {Database.usuarioLogado.Nome}!");

            sbyte escolha = 0;
            do{
                Console.WriteLine("O que deseja fazer?\n1 - Efetuar transação\n2 - Mostrar Saldo\n3 - Mostrar Relatorio\n4 - Fazer Logoff\n5 - Exportar database");
                sbyte.TryParse(Console.ReadLine(),out escolha);
                switch (escolha)
                {                
                    case 1:
                        EfetuarTransacao();
                        break;
                    case 2:
                        MostrarSaldo();
                        break;
                    case 3:
                        MostrarRelatorio();
                        break;
                    case 4:
                        Database.usuarioLogado = null;
                        break;
                    case 5:
                        Database.Exportar();
                        break;
                    default:
                        Design.MensagemErro("Valor invalido! ");
                        Design.MensagemProximo("Aperte qualquer tecla para continuar");
                        Console.Clear();
                    break;
                }
                Database.SalvarDatabase();
            }while(escolha !=4);
        }
        #endregion
        #region Metodos deslogado
        
        /// <summary>
        /// Método que mostra a tela de cadastro do usuário, e pede nome, e-mail e senha
        /// </summary>
        public static void CadastrarUsuario(){
            Console.Clear();
            //criando usuario
            Usuario usuario = new Usuario();

            // Inserindo o nome do usuário
            do
            {
                Design.MensagemInstrucao("Digite o seu nome");
                usuario.Nome = Console.ReadLine();      

                if (string.IsNullOrEmpty(usuario.Nome)){
                    Console.WriteLine("Nome inválido");
                }
            }
            while (string.IsNullOrEmpty(usuario.Nome));
            Console.Clear();

            // Inserindo o e-mail
            do
            {
                Design.MensagemInstrucao("Digite o seu endereço de e-mail");
                usuario.Email = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(usuario.Email));
            Console.Clear();

            // Inserindo a senha
            do{
                Design.MensagemInstrucao("Digite a sua senha");
                usuario.Senha = Console.ReadLine();
            }while (string.IsNullOrEmpty(usuario.Senha));
            Console.Clear();

            //inserindo data de nascimento
            do{
                Design.MensagemInstrucao("Digite a sua data de nascimento");
                DateTime.TryParse(Console.ReadLine(),out DateTime tempData);
                usuario.DataNascimento = tempData;
            }while(string.IsNullOrEmpty(usuario.dataNascimento));
            Console.Clear();

            Database.InserirUsuario(usuario);
        }
        /// <summary>
        /// Menu onde o usuario deve inserir seu email e sua senha que serão procurados no Database e validados  
        /// Caso o usuario insira a combinação correta de senha e email ele sera redirecionado para o menu logado
        /// Ao contrario irá retornar para o menu principal
        /// </summary>
        private static void Logar(){
            Console.Clear();
            string email , senha;

            Design.MensagemInstrucao("Digite o seu email");
            email = Console.ReadLine();

            Usuario usuarioSelecionado = Database.ValidarEmail(email);
            if(usuarioSelecionado != null){
                sbyte tentativas = 0;
                do{
                Design.MensagemInstrucao("Digite a sua senha");
                senha = Console.ReadLine();
                    if(senha == usuarioSelecionado.Senha){
                        Database.usuarioLogado = usuarioSelecionado;
                        break;
                    }else{
                        Design.MensagemErro("Senha incorreta");
                        tentativas++;
                    }
                    //flag
                    if(tentativas == 3)
                        Design.MensagemErro("Maximo de tentativas atingido");
                        Design.MensagemProximo("Aperte qualquer tecla para continuar");
                }while(tentativas < 3);
            }else{
                Design.MensagemErro("Não existe nenhuma conta com este email");
                Design.MensagemProximo("Aperte qualquer tecla para continuar");
            }
            
        }
        #endregion

        #region Metodos logado
        
        /// <summary>
        /// Recebe dados do usuario e cria uma transação e salva elas no ID do usuario  
        /// </summary>
        private static void EfetuarTransacao(){
            int escolha = 0;
            do{
                Console.Clear();
                Design.MensagemInstrucao("Insira o tipo de transação");

                Console.WriteLine("1 - Despesa\n2 - Receita\n3 - Sair");
                
                int.TryParse(Console.ReadLine(),out escolha);

                Transacao transacao = new Transacao();
                transacao.tipo = (tipoTransacao)escolha;
                switch (escolha)
                {
                    case 1 :
                    case 2 :  
                        Console.Clear();
                        Design.MensagemInstrucao("Insira uma descrição para a transação");
                        transacao.Descricao = Console.ReadLine();

                        Console.Clear();
                        Design.MensagemInstrucao("Insira a data da transação");                        
                        DateTime.TryParse(Console.ReadLine(),out DateTime data);
                        transacao.ValidarData(data);

                        Console.Clear();
                        Design.MensagemInstrucao("Insira um valor para a transação");
                        double.TryParse(Console.ReadLine(),out double tempValor);
                        transacao.ValidarValor(tempValor);

                        Database.InserirTransacao(transacao);
                        break;                    
                    case 3:
                        transacao = null;
                        Design.MensagemProximo("Aperte qualquer tecla");
                        break;
                    default:
                        Design.MensagemErro("Valor invalido");
                        Design.MensagemProximo("Aperte qualquer tecla para continuar");
                        Console.Clear();
                        break;
                }
                Database.SalvarDatabase();
            }while(escolha != 3);
        }
        /// <summary>
        /// Mostra o saldo do usuario baseando-se na lista de transações
        /// </summary>
        private static void MostrarSaldo(){
            double Saldo = 0;
            List<Transacao> lista = Database.BuscarTransacao(Database.usuarioLogado.ID);
            foreach (Transacao item in lista)
            {               
                Saldo += item.ValorDespesa;
            }
            Console.WriteLine("");
            Design.MensagemSucesso($"Seu saldo é de R${Saldo.ToString("N2")}");
            Console.WriteLine("");
        }

        #endregion

        #region Relatorios
        /// <summary>
        /// Abre um menu onde o usuario deve escolher entre gerar um arquivo .docx contendo : 
        /// 1 - Somente suas transações
        /// 2 - Lista de todos os usuarios 
        /// </summary>
        private static void MostrarRelatorio(){
            Console.WriteLine("Insira a opção desejada\n1 - Relatorio de usuarios cadastrados\n2 - Relatorio de suas transações");
            sbyte.TryParse(Console.ReadLine(),out sbyte escolha);
            switch (escolha)
            {
                case 1:
                    Relatorio.GerarRelatorioUsuarios();
                    break;
                case 2:
                    Relatorio.GerarRelatorioUsuario();
                    break;
                default:
                    Design.MensagemErro("Valor invalido");
                    Design.MensagemProximo("Aperte qualquer tecla para continuar");
                    break;
            }

        }
        #endregion
    }
}
