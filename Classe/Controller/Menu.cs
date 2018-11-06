using System;
using System.Collections.Generic;

namespace FinancaDeMesa.Classe.Controller
{
    public static class Menu
    {
        /// <summary>
        /// Método que mostra a tela de cadastro do usuário, e pede nome, e-mail e senha
        /// </summary>
        public static void CadastrarUsuario(){
            string nome, email, senha;

            // Inserindo o nome do usuário
            do
            {
                System.Console.WriteLine("Digite o seu nome");
                nome = Console.ReadLine();
                
                if (string.IsNullOrEmpty(nome))
                {
                    Console.WriteLine("Nome inválido");
                }
            }
            while (string.IsNullOrEmpty(nome));

            // Inserindo o e-mail
            do
            {
                Console.WriteLine("Digite o seu endereço de e-mail (deve conter '@' e '.");
                email = Console.ReadLine();

            }
            while (string.IsNullOrEmpty(email));
        }
    }   
}
