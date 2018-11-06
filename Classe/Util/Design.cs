using System;
using System.Text;
namespace FinancaDeMesa.Classe.Util
{
    public static class Design
    {
        /// <summary>
        /// Mostra uma mensagem de sucesso :     
        /// ===| mensagem |====
        /// </summary>
        /// <param name="mensagem"></param>
        public static void MensagemSucesso(string mensagem){
            Console.WriteLine($"===| {mensagem} |====");
        }
        /// <summary>
        /// Mostra uma mensagem de instrução :     
        /// >>> mensagem <<<
        /// </summary>
        /// <param name="mensagem"></param>
        public static void MensagemInstrucao(string mensagem){
            Console.WriteLine($">>> {mensagem} <<<");
        }
        /// <summary>
        /// Mostra uma mensagem de erro :     
        /// mensagem ≧◡≦
        /// </summary>
        /// <param name="mensagem"></param>
        public static void MensagemErro(string mensagem){
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{mensagem} ≧◡≦");
        }
    }
}