using System;
using System.Collections.Generic;
using FinancaDeMesa.Classe.Models;
using FinancaDeMesa.Classe.Util;

namespace FinancaDeMesa.Classe.Controller
{
    public static class Menu
    {
        #region Metodos deslogado
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
                Console.WriteLine("O Que deseja fazer?\n1- Se Cadastrar\n2 - Login\n3 - Sair");

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
            }while(escolha != 3);
        }
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
                usuario.DataNascimento = DateTime.Parse(Console.ReadLine());
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

            //percorre toda a lista no banco de dados
            foreach(Usuario usuario in Database.usuarios){
                //se encontrar um email igual ao inserido
                if(email == usuario.Email){
                    //loop para o usuario inserir a senha (3 tentativas)
                    sbyte tentativas = 0;
                    do{
                    Design.MensagemInstrucao("Digite a sua senha");
                    senha = Console.ReadLine();
                        if(senha == usuario.Senha){
                            Database.usuarioLogado = usuario;
                        }else{
                            Design.MensagemErro("Senha incorreta");
                            tentativas++;
                        }
                        //flag
                        if(tentativas == 3)
                            Design.MensagemErro("Maximo de tentativas atingido");
                    }while(senha != usuario.Senha && tentativas < 3);

                    break;
                }
            }
            //flag
            if(Database.usuarioLogado == null){
                Design.MensagemErro("Não existe nenhuma conta com este email");
                Design.MensagemProximo("Aperte qualquer tecla para continuar");
            }
            
        }
        #endregion

        #region Metodos logado
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
                Console.WriteLine("O que deseja fazer?\n1 - Efetuar transação\n2 - Mostrar Saldo\n3 - Mostrar Relatorio\n4 - Fazer Logoff");
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
                        Logoff();
                        break;
                    default:
                    break;
                }
            }while(escolha !=4);
        }
        /// <summary>
        /// Recebe dados do usuario e cria uma transação e salva elas no ID do usuario  
        /// </summary>
        private static void EfetuarTransacao(){
            sbyte escolha = 0;
            do{
                Design.MensagemInstrucao("Insira o tipo de transação");
                sbyte.TryParse(Console.ReadLine(),out escolha);
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
                switch (item.tipo)
                {
                    case tipoTransacao.Despesa:
                        Saldo -= item.ValorDespesa;
                        break;
                    case tipoTransacao.Receita:
                        Saldo += item.ValorDespesa;
                        break;
                    default:
                        Saldo = 0;
                        break;
                    }
            }
            Console.WriteLine($"\nSeu saldo é de R${Saldo.ToString("N2")}\n");
        }
        /// <summary>
        /// Salva o banco de dados em um arquivo .zip
        /// </summary>
        private static void ExportarDataBase(){

        }

        #endregion

        #region Relatorios
        /// <summary>
        /// Abre um menu onde o usuario deve escolher entre gerar um arquivo .docx contendo : 
        /// 1 - Somente suas transações
        /// 2 - Lista de todos os usuarios 
        /// </summary>
        private static void MostrarRelatorio(){

        }
        private static void MostrarTodos(){

        }
        private static void MostrarTransacao(){

        }
        private static void Logoff(){

        }
        #endregion
    }
}
