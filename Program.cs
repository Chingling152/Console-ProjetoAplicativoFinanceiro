using System;
using FinancaDeMesa.Classe.Util;

namespace FinancaDeMesa
{
    class Program
    {
        static void Main(string[] args)
        {
            //Apresentação
            Design.MensagemChamativa("Seja bem vindo!");
            Design.MensagemProximo("Aperte qualquer tecla para continuar");

            //Todo o programa ae ;-;
            FinancaDeMesa.Classe.Controller.Menu.Deslogado();

            //Fim
            Design.MensagemProximo("Aperte qualquer tecla para sair");
        }
    }
}
