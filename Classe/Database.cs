using System.IO;
using System;
using System.IO.Compression;
using System.Collections.Generic;
using FinancaDeMesa.Classe.Models;

namespace FinancaDeMesa.Classe
{
    public static class Database
    {
        public static Usuario usuarioLogado;
        private static List<Usuario> usuarios = new List<Usuario>();
        private static List<Transacao> transacoes = new List<Transacao>();

        /// <summary>
        /// Gera um id para o usuario criado e o adiciona ao banco de dados
        /// </summary>
        /// <param name="usuario"></param>
        public static void InserirUsuario(Usuario usuario){
            usuario.ID = usuarios.Count +1;
            usuarios.Add(usuario);
        }
    }
}