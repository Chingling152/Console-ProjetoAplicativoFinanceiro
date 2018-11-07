using System;
using FinancaDeMesa.Classe.Util;

namespace FinancaDeMesa.Classe.Models {

    public enum tipoTransacao {
        Despesa = 1,
        Receita = 2,
    }
    public class Transacao {
        /// <summary>
        /// Id da transacao
        /// </summary>
        public int ID;
        /// <summary>
        /// Define o tipo de transação que será feita
        /// </summary>
        public tipoTransacao tipo;
        /// <summary>
        /// Define a descrição da transação
        /// </summary>
        public string Descricao;
        /// <summary>
        /// Representa a qual usuario essa transação pertence
        /// </summary>
        public int IDUsuario;
        public string dataTransacao{
            get;
            private set;
        }
        public double ValorDespesa{
            get;
            private set;
        }

        /// <summary>
        /// Converte o valor inserido pelo usuario
        /// </summary>
        /// <param name="valor">Qualquer valor numerico</param>
        public void ValidarValor (double valor) {
            switch (tipo) {
                case tipoTransacao.Despesa:
                    if(valor >= 0){
                        ValorDespesa = valor * -1;
                    }else{
                        ValorDespesa = valor;
                    }
                    break;
                case tipoTransacao.Receita:
                    if(valor >= 0){
                        ValorDespesa = valor;
                    }else{
                        ValorDespesa = valor * (- 1);
                    }
                    break;
                default:
                    Design.MensagemErro("Isso não devia acontecer ;-; não sei como você fez isso mas ...  saia já");
                    break;
            }
        }
        /// <summary>
        /// Valida a data inseirda pelo usuario e transforma ela em uma string 
        /// </summary>
        /// <param name="data">Qualquer valor de data</param>
        public void ValidarData(System.DateTime data){
            if(data.Year >= DateTime.Now.Year ){
                if(data.Month >= DateTime.Now.Month ){
                    if(data.Day > DateTime.Now.Day){
                        data = DateTime.Now;
                    }
                }
            }
            dataTransacao =data.ToShortDateString();
        }
    } 
}