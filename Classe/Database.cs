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
        /// Lista onde ficam armazenadas todas as transações
        /// </summary>
        /// <value></value>
        public static List<Transacao> transacoes{
            private set ; 
            get;
        } = new List<Transacao>();

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
        /// <summary>
        /// Retorna uma lista de transações que combinem com o id inserido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Transacao> BuscarTransacao(int id){
            List<Transacao> lista = new List<Transacao>();
            foreach (Transacao item in transacoes)
            {
                if(item.ID == id){
                    lista.Add(item);
                }
            }
            return lista;
        } 
    }
}