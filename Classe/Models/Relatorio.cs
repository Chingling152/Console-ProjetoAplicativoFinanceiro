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
    public static class Relatorio
    {
        public static void GerarRelatorioUsuarios()
        {
            Document documento = new Document();

            Section secao = documento.AddSection();

            Paragraph titulo  = secao.AddParagraph();
            titulo.Format.HorizontalAlignment = HorizontalAlignment.Center;
            titulo.AppendText("Relatorio de usuarios cadastrados");

            foreach (Usuario item in Database.usuarios)
            {
                if(item != null){
                    Paragraph[] informacao = new Paragraph[3];
                    foreach (Paragraph par in informacao){
                        secao.AddParagraph();
                    }
                    secao.AddParagraph().AppendText("\n");
                    informacao[0].AppendText($"Nome : {item.Nome}");
                    informacao[1].AppendText($"Email : {item.Email}");
                    informacao[2].AppendText($"Data De Nascimento : {item.dataNascimento}");
                    secao.AddParagraph().AppendText("\n");
                }
            }

        }

        public static void GerarRelatorioUsuario()
        {
            // Criando o relatório
            Document documento = new Document();
        
            //Adicionando uma seção ao relatório
            Section secao = documento.AddSection();

            //Adicionando um parágrafo à seção
            Paragraph titulo  = secao.AddParagraph();

            titulo.Format.HorizontalAlignment = HorizontalAlignment.Center;

            titulo.AppendText($"{Database.usuarioLogado.ID} | {Database.usuarioLogado.Nome} | {Database.usuarioLogado.Email}");
            secao.AddParagraph().AppendText("\n");

            List<Transacao> transacoes = Database.BuscarTransacao(Database.usuarioLogado.ID);
            
            if(transacoes.Count > 0){
                foreach (Transacao tra in transacoes)
                {
                    if(tra != null){
                        Paragraph[] informacao = new Paragraph[4];
                        foreach (Paragraph item in informacao)
                        {
                            secao.AddParagraph();
                        }

                        Paragraph tituloTransacao  = secao.AddParagraph();
                        tituloTransacao.AppendText($"Transação {tra.ID}");
                        secao.AddParagraph().AppendText("\n");
                        informacao[0].AppendText($"Tipo : {tra.tipo}");
                        informacao[1].AppendText($"Data : {tra.dataTransacao}");
                        informacao[2].AppendText($"Descrição : {tra.dataTransacao}");
                        informacao[3].AppendText($"Data da transação : {tra.dataTransacao}");
                        secao.AddParagraph().AppendText("\n");
                    }
                }

                //Salvando o relatório
                documento.SaveToFile($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\relatorio{Database.usuarioLogado.Nome}.docx",FileFormat.Docx);
                Design.MensagemSucesso($@"Arquivo relatorio{Database.usuarioLogado.Nome}.docx criado na area de trabalho");
                Design.MensagemProximo("Aperte qualquer botão para continuar (exceto o printscreen)");
            }else{
                Design.MensagemErro($"O Usuario {Database.usuarioLogado.Nome} não efetuou transações");
                Design.MensagemProximo("Aperte qualquer botão para continuar (exceto o printscreen)");
            }
        } 
    }
}
