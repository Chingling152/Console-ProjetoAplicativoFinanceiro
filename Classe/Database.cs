using System.IO;
using System;
using System.IO.Compression;
using System.Collections.Generic;
using FinancaDeMesa.Classe.Models;
using FinancaDeMesa.Classe.Util;

namespace FinancaDeMesa.Classe
{
    public static class Database
    {
        #region Usuarios
        public static Usuario usuarioLogado = null;
        /// <summary>
        /// Lista onde ficam armazenados todos os usuarios
        /// </summary>
        /// <value></value>
        public static List<Usuario> usuarios {
            private set ; 
            get;
        } = new List<Usuario>();

        /// <summary>
        /// Gera um id para o usuario criado e o adiciona ao banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        public static void InserirUsuario(Usuario usuario){
            usuario.ID = usuarios.Count +1;
            usuarios.Add(usuario);
            Design.MensagemSucesso($"Usuario {usuario.Nome} adicionado no id {usuario.ID} com sucesso!");
            Design.MensagemProximo("Aperte qualquer tecla para continuar");
        }
        #endregion
        
        #region Transações
        
        /// <summary>
        /// Lista onde ficam armazenadas todas as transações
        /// </summary>
        /// <value></value>
        public static List<Transacao> transacoes{
            private set ; 
            get;
        } = new List<Transacao>();
        /// <summary>
        /// Retorna uma lista de transações que combinem com o id inserido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Transacao> BuscarTransacao(int id){
            List<Transacao> lista = new List<Transacao>();
            foreach (Transacao item in transacoes)
            {
                if(item.IDUsuario == id){
                    lista.Add(item);
                }
            }
            return lista;
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transacao"></param>
        public static void InserirTransacao(Transacao transacao){
            transacao.ID = transacoes.Count +1;
            transacao.IDUsuario = usuarioLogado.ID;

            transacoes.Add(transacao);
            Design.MensagemSucesso($"Transação {transacao.ID} adicionado no usuario {usuarioLogado.Nome} com sucesso!");
            Design.MensagemProximo("Aperte qualquer tecla para continuar");
        }
        #endregion

        #region Banco De Dados

        /// <summary>
        /// Nome do arquivo que será criado para armazenar a lista de usuarios
        /// </summary>
        public static string UsuarioDBNome = "Usuario.csv";

        /// <summary>
        /// Nome do arquivo que será criado para armazenar a lista de transações
        /// </summary>
        public static string TransacaoDBNome = "Transacao.csv";

        /// <summary>
        /// 
        /// </summary>
        public static void SalvarDatabase(){
            SalvarUsuarios();
            SalvarTransacoes();
        }
        /// <summary>
        /// Salva todos os usuarios da lista usuarios em um arquivo .csv 
        /// </summary>
        private static void SalvarUsuarios(){
            StreamWriter usuarioDB = new StreamWriter(UsuarioDBNome);
            foreach (Usuario item in usuarios)
            {
                if(item != null){
                    usuarioDB.WriteLine($"{item.ID};{item.Nome};{item.Email};{item.Senha};{item.dataNascimento}");
                }
            }
            usuarioDB.Close();
        }
        /// <summary>
        /// Salva todas as transações da lista transações em um arquivo .csv
        /// </summary>
        private static void SalvarTransacoes(){
            StreamWriter transacaoDB = new StreamWriter(TransacaoDBNome);
            foreach (Transacao item in transacoes)
            {
                if(item != null){
                    transacaoDB.WriteLine($"{item.ID};{item.Descricao};{(int)item.tipo};{item.ValorDespesa};{item.dataTransacao};{item.IDUsuario}");
                }
            }
            transacaoDB.Close();
        }

        public static void CarregarDatabase(){
            if(!File.Exists($@"{Environment.CurrentDirectory}\{UsuarioDBNome}")){
                StreamWriter usuarioDB = new StreamWriter(UsuarioDBNome);
                usuarioDB.Close();
            }

            if(!File.Exists($@"{Environment.CurrentDirectory}\{TransacaoDBNome}")){
                StreamWriter transacaoDB = new StreamWriter(TransacaoDBNome);
                transacaoDB.Close();
            }

            usuarios = CarregarUsuario();
            transacoes = CarregarTransacao();
        }

        private static List<Usuario> CarregarUsuario(){
            List<Usuario> tempDB = new List<Usuario>();
            StreamReader leitor = new StreamReader(UsuarioDBNome);

            while (!leitor.EndOfStream)
            {
                string[] informacao = leitor.ReadLine().Split(';');
                Usuario usuario = new Usuario(){
                    ID = int.Parse(informacao[0]),
                    Nome = informacao[1],
                    Email = informacao[2],
                    Senha = informacao[3],
                    DataNascimento = DateTime.Parse(informacao[4])
                };
                tempDB.Add(usuario);
            }

            leitor.Close();
            return tempDB;
        }
        private static List<Transacao> CarregarTransacao(){
            List<Transacao> tempDB = new List<Transacao>();
            StreamReader leitor = new StreamReader(TransacaoDBNome);

            while (!leitor.EndOfStream)
            {
                string[] informacao = leitor.ReadLine().Split(';');
                Transacao transacao = new Transacao(){
                    ID = int.Parse(informacao[0]),
                    Descricao = informacao[1],
                    tipo = (tipoTransacao)int.Parse(informacao[2]),
                    IDUsuario = int.Parse(informacao[5])
                };
                transacao.ValidarValor(double.Parse(informacao[3]));
                transacao.ValidarData(DateTime.Parse(informacao[4]));

                tempDB.Add(transacao);
            }
            
            leitor.Close();
            return tempDB;
        }
        #endregion

        #region Validação
        /// <summary>
        /// Verifica se existe algum usuario no banco de dados com o email inserido e o retorna
        /// </summary>
        /// <param name="email">Email do usuario a ser procurado</param>
        /// <returns>O usuario encontrado (caso não exista , retorna null)</returns>
        public static Usuario ValidarEmail(string email){
            Usuario retorno = null;
            //percorre toda a lista no banco de dados
            foreach(Usuario usuario in Database.usuarios){
                //se encontrar um email igual ao inserido
                if(email == usuario.Email){
                    retorno = usuario;
                    break;
                }
            }
            return retorno;
        }
        #endregion
    }
}