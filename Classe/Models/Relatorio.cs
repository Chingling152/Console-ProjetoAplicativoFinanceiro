using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using FinancaDeMesa.Classe.Models;
using FinancaDeMesa.Classe.Util;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace FinancaDeMesa.Classe.Models
{
    class Relatorio
    {
        public Relatorio(string valor)
        {

            
            // Criando o relatório
            Document documento = new Document();
        
            //Adicionando uma seção ao relatório
            Section secao = documento.AddSection();

            //Adicionando um parágrafo à seção
            Paragraph paragrafo = secao.AddParagraph();

            TextRange TR = paragrafo.AppendText($"{Database.usuarioLogado}");

            //Salvando o relatório
            documento.SaveToFile(@"C:\Users\35482820831\Desktop\relatorio.docx",FileFormat.Docx);
        } 
    }
}
