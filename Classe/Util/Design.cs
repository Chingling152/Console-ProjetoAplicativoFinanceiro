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
        /// Mostra uma mensagem de instrução    
        /// </summary>
        /// <param name="mensagem">A Mensagem que seá exibida</param>
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
        /// <summary>
        /// Mostra uma mensagem "Aperte qualquer tecla para continuar"
        /// e só sai do metodo caso o usuario aperte alguma tecla  
        /// quando o usuario aperta qualquer tecla o console é limpado
        /// </summary>
        public static void MensagemProximo(){
            MensagemInstrucao("Aperte qualquer tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Mostra uma mensagem
        /// </summary>
        /// <param name="mensagem"></param>
        public static void MensagemChamativa(string mensagem){
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine ($"{new string('_',mensagem.Length + 2)} \n| {mensagem} |\n {new string('‾',mensagem.Length + 2 )} ");
        }
    }
}