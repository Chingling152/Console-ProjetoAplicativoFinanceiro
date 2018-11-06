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
            Design.MensagemProximo();

            //Todo o programa ae ;-;
            FinancaDeMesa.Classe.Controller.Menu.Deslogado();

            //Fim
            Design.MensagemChamativa("Até um outro dia!");
            Design.MensagemProximo();
        }
    }
}
