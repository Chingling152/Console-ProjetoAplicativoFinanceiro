using System;
namespace FinancaDeMesa.Classe.Controller
{
    public static class Menu
    {
        private static bool Vazia(){
            return false;
        }
        #region Metodos deslogado
        /// <summary>
        /// Menu onde o usuario terá que inserir um dos valores abaixo :  
        /// 1 - Cadastrar-se (Metodo Cadastrar)  
        /// 2 - Logar (Metodo Logar)     
        /// 3 - Sair (Ignora o do while)  
        /// Qualquer outro valor sera ignorado  
        /// </summary>
        public static void Deslogado(){

        }
        private static void Cadastrar(){

        }
        private static void Logar(){

        }
        #endregion

        #region Metodos logado
        /// <summary>
        /// Menu onde o usuario deve inserir um dos valores abaixo :  
        /// 1 - Efetuar Transação     
        /// 2 - Mostrar Extrato   
        /// 3 - Mostrar Relatorio   
        /// 4 - Fazer logoff (MenuDeslogado)  
        /// </summary>
        public static void Logado(){

        }
        /// <summary>
        /// Recebe dados do usuario e cria uma transação e salva elas no ID do usuario  
        /// </summary>
        private static void EfetuarTransacao(){

        }
        /// <summary>
        /// Mostra todas as transações feitas pelo usuario
        /// </summary>
        private static void MostrarExtrato(){

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
        #endregion
    }
}