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
        
        private string nome;

        /// <summary>
        /// Define o nome do usuario
        /// </summary>
        public string Nome{
            set{
                bool invalido = false;
                for(int i = 0 ; i < 10;i++){
                    if(value.Contains(i.ToString())){
                        Design.MensagemErro("Valor invalido ;-; não pode numeros");
                        invalido = true;
                        break;
                    }
                }

                if(!invalido){
                    nome = value;
                }
            }
            get{
                return nome;
            }
        }
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
                    email = value.ToLower();
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
                if(value.Length >= 8){
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
                if(System.DateTime.Now.Year - value.Year < 18 || System.DateTime.Now.Year - value.Year > 100){
                    Design.MensagemErro("Idade invalida");
                }else{
                    dataNascimento = value.ToShortDateString();
                }
            }
        }
        #endregion
    }
}