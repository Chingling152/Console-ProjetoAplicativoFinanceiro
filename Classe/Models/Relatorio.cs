using System;
using System.Diagnostics;
using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace FinancaDeMesa.Classe.Models
{
    class Relatorio
    {
        static void Main(string[] args)
        {
            #region Criando o formulário
            // Criando o formulário
            Relatorio relatorio = new Relatorio();
            #endregion

            #region Adicionando uma seção ao relatório
            //Adicionando uma seção ao relatório
            Section secao = relatorio.AddSection();
            #endregion

            #region Adicionando um parágrafo à seção
            //Adicionando um parágrafo à seção
            Paragraph paragrafo = secao.AddParagraph();
            #endregion

            #region Salvando o relatório
            //Salvando o relatório
            relatorio.SaveToFile(@"C:\Users\35482820831\Desktop\relatorio.docx",FileFormat.Docx);
            #endregion
        }

        //??
        private void SaveToFile(string v, FileFormat docx)
        {
            throw new NotImplementedException();
        }
        
        //???
        private Section AddSection()
        {
            throw new NotImplementedException();
        }
    }
}
