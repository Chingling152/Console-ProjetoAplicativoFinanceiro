using System;
namespace FinancaDeMesa.Classe.Models {

    public enum tipoTransacao {
        Despesa = 1,
        Receita = 2,
        Invalido = 0
    }
    public class Transacao {
        public int Id;
        public tipoTransacao tipo;
        public string Descricao;
        private string dataTransacao;
        private double ValorDespesa;
        public void ValidarValor (double valor) {
            switch (tipo) {
                case tipoTransacao.Despesa:
                    ValorDespesa = valor * -1;
                    break;

                case tipoTransacao.Receita:
                    ValorDespesa = valor;
                    break;

                default:
                    
                    break;
            }
        }
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