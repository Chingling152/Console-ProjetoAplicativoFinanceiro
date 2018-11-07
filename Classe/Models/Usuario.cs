using FinancaDeMesa.Classe.Util;

namespace FinancaDeMesa.Classe.Models
{
    public class Usuario
    {
        #region Variaveis
        /// <summary>
        /// Define o ID do usuario
        /// </summary>
        public int ID;
        /// <summary>
        /// Deine o nome do usuario
        /// </summary>
        public string Nome;
        private string email;
        private string senha;
        /// <summary>
        /// Apenas leitura publica  
        /// Define a data de nasicmento do usuario
        /// </summary>
        /// <value></value>
        public string dataNascimento{
            get ;
            private set;
        }
        #endregion

        #region Validação
        /// <summary>
        /// Define o email do usuario
        /// </summary>
        /// <value>**valor valido** : Uma string que contenha @ e .</value>
        public string Email {           
            get{
                return email;
            }
            set{
                if(value.Contains('@') && value.Contains('.')){
                    email = value;
                }else{
                    Design.MensagemErro("O Email inserido é invalido");
                }
            }
        }
        /// <summary>
        /// Define a variavel senha igual à senha inserida  
        /// </summary>
        /// <value>**Valor valido** : Senha com mais de 8 caracteres </value>
        public string Senha{
            get{
                return senha;
            }
            set{
                if(value.Length > 8){
                    senha = value;
                }else{
                    Design.MensagemErro("A senha inserida é invalida");
                }
            }
        }
        /// <summary>
        /// Define a variavel dataNascimento igual a data inserida  
        /// </summary>
        /// <value>**Valor valido** : data de nascimento com diferença de 18 anos ou mais da data atual</value>
        public System.DateTime DataNascimento{
            set {
                if(value.Year - System.DateTime.Now.Year < 18){
                    Design.MensagemErro("Menor de 18 anos num pode ;-;");
                }else{
                    dataNascimento = value.ToShortDateString();
                }
            }
        }
        #endregion
    }
}