using System;
using System.Collections.Generic;
using System.Windows.Forms;
using wd = Microsoft.Office.Interop.Word;

namespace MalaDiretaWord
{
    public class AlterarTextosWord
    {

        //copiar arquivo modelo para novo diretorio, renomeando
        string usuario = Environment.UserName.ToString();
        string diaDoAno = DateTime.Now.DayOfYear.ToString();
        string ano = DateTime.Now.Year.ToString();
        string hora = DateTime.Now.Hour.ToString();
        string minuto = DateTime.Now.Minute.ToString();
        string segundo = DateTime.Now.Second.ToString();


        /// <summary>
        /// Alterar textos pré definidos em um documento Word.
        /// </summary>
        /// <param name="EnderecoArquivo">Local de origem do arquivo modelo word, sendo REF devolve o novo endereco do arquivo e nome</param>
        /// <param name="ListaAlteracoes">@textoLocalizar;Novo Texto</param>
        /// <param name="fecharWordDepoisAlteracao">Determinar se o Laudo deve ser fechado após atualização</param>
        /// <param name="renomear">Aplicar extensão de renomeando do arquivo: usuario + diadoano + ano + hora + minuto + segundo </param>
        /// <param name="textoRenomear">Acrescentar sufixo personalizado</param>
        /// <param name="enderecoDestino">Determina o local onde dever ser salvo o Laudo após atualizado. Se não informado é encaminhado para a desktop.</param>
        /// <returns></returns>
        public bool AlterarTexto(ref string EnderecoArquivo, List<string> ListaAlteracoes,
                                    Boolean fecharWordDepoisAlteracao = true, Boolean renomear = false,
                                        string textoRenomear = "", string enderecoDestino = "")
        {

            try
            {

                //Renomeando e copiando o arquivo para uma área de edição
                EnderecoArquivo = CopiarArquivo(EnderecoArquivo, enderecoDestino, renomear, textoRenomear);
                //Instanciando o word e carregando o arquivo
                wd.Application wordApp = new wd.Application();
                var doc = wordApp.Documents.Open(EnderecoArquivo);


                //determinando a visibilidade do processo
                wordApp.Visible = true;
                //Substituir textos                
                substituirTexto(ListaAlteracoes, wordApp);
                //Salvar
                doc.Save();
                //Exibir
                wordApp.Visible = true;
                //fechar
                if (fecharWordDepoisAlteracao)
                {
                    wordApp.Quit();
                }

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                return false;
            }

        }


        private string CopiarArquivo(string EnderecoOrigem, string EnderecoDestino, Boolean renomear = false, string textoRenomear = "")
        {

            try
            {

                string posFixoRenomear = usuario + "_" + diaDoAno + "_" + ano + "_" + hora + "_" + minuto + "_" + segundo + "_" + textoRenomear;

                //identificando o arquivo na string de orgiem
                string arquivo = System.IO.Path.GetFileNameWithoutExtension(EnderecoOrigem); // sem a extensão
                string extensaoArquivo = System.IO.Path.GetExtension(EnderecoOrigem); // apenas a extensão


                //Renomeando arquivo caso seja especificado na chamada da biblioteca
                if (renomear)
                {
                    arquivo = arquivo.Replace(" ", "_") + "_" + posFixoRenomear + extensaoArquivo;
                }

                //se endereço de destino for vazio, encaminhar para o desktop do próprio usuário
                if (string.IsNullOrEmpty(EnderecoDestino))
                {
                    EnderecoDestino = @"C:\Users\" + usuario + @"\Desktop\";
                }

                // Use a classe Path para manipular caminhos de arquivos e diretórios.
                string sourceFile = EnderecoOrigem;
                string destFile = System.IO.Path.Combine(EnderecoDestino, arquivo);

                // Para copiar um arquivo para outro local e
                // Sobrescrever o arquivo de destino, se já existir.
                System.IO.File.Copy(@sourceFile, @destFile, true);

                return @destFile;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                return "";
            }

        }


        private bool substituirTexto(List<string> ListaAlteracoes, wd.Application appWord)
        {
            try
            {
                string localizarTexto = "";
                string novoTexto = "";
                string[] parametros;

                foreach (string textoSplit in ListaAlteracoes)
                {
                    //Quebrando as informações
                    parametros = textoSplit.Split(';');
                    localizarTexto = parametros[0].ToString();
                    novoTexto = parametros[1].ToString();


                    //Verificando se a substituição refere-se a uma IMAGEM
                    //Se o texto para substituição começa com @imagem
                    if (localizarTexto.StartsWith("@imagem"))
                    {
                        inserirImagem(novoTexto, localizarTexto, appWord);
                        continue; //saltar o laço
                    }

                    //configurando a localização e substituição
                    appWord.Selection.Find.Text = localizarTexto;
                    appWord.Selection.Find.Replacement.Text = "";
                    appWord.Selection.Find.Forward = true;
                    appWord.Selection.Find.Format = false;
                    appWord.Selection.Find.MatchCase = false;
                    appWord.Selection.Find.MatchWholeWord = false;
                    appWord.Selection.Find.MatchWildcards = false;
                    appWord.Selection.Find.MatchSoundsLike = false;
                    appWord.Selection.Find.MatchAllWordForms = false;


                    //CABEÇALHO DE TODAS AS PÁGINAS
                    appWord.ActiveWindow.View.SeekView = wd.WdSeekView.wdSeekPrimaryHeader;
                    while (appWord.Selection.Find.Execute())
                    {
                        appWord.Selection.Select();
                        Clipboard.SetDataObject(novoTexto);
                        appWord.Selection.Paste();
                    }

                    //CABEÇALHO DA PÁGINA DE ROSTO
                    appWord.ActiveWindow.View.SeekView = wd.WdSeekView.wdSeekFirstPageHeader;
                    while (appWord.Selection.Find.Execute())
                    {
                        appWord.Selection.Select();
                        Clipboard.SetDataObject(novoTexto);
                        appWord.Selection.Paste();
                    }

                    //RODAPÉ DE TODOS AS PÁGINAS
                    appWord.ActiveWindow.View.SeekView = wd.WdSeekView.wdSeekPrimaryFooter;
                    while (appWord.Selection.Find.Execute())
                    {
                        appWord.Selection.Select();
                        Clipboard.SetDataObject(novoTexto);
                        appWord.Selection.Paste();
                    }

                    //RODAPÉ DA PÁGINA DE ROSTO
                    appWord.ActiveWindow.View.SeekView = wd.WdSeekView.wdSeekFirstPageFooter;
                    while (appWord.Selection.Find.Execute())
                    {
                        appWord.Selection.Select();
                        Clipboard.SetDataObject(novoTexto);
                        appWord.Selection.Paste();
                    }

                    //CORPO DO DOCUMENTO
                    appWord.ActiveWindow.View.SeekView = wd.WdSeekView.wdSeekMainDocument;
                    while (appWord.Selection.Find.Execute())
                    {
                        appWord.Selection.Select();
                        Clipboard.SetDataObject(novoTexto);
                        appWord.Selection.Paste();
                    }

                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                return false;
            }
        }



        private bool inserirImagem(string enderecoImagem, string localizacaoImagemNoDocWord, wd.Application appWord)
        {
            try
            {

                //CORPO DO DOCUMENTO
                appWord.ActiveWindow.View.SeekView = wd.WdSeekView.wdSeekMainDocument;
                //localizar onde inserir a imagem
                appWord.Selection.Find.Text = localizacaoImagemNoDocWord;

                while (appWord.Selection.Find.Execute())
                {
                    //inserir a imagem                                 
                    appWord.Selection.Select();
                    Clipboard.SetDataObject(appWord.Selection.InlineShapes.AddPicture(enderecoImagem));
                    //appWord.Selection.Paste();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                return false;
            }
        }


    }
}
