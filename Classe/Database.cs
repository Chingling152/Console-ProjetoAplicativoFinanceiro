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

        public static void InserirUsuario(Usuario usuario){
            usuarios.Add(usuario);
        }
    }
}