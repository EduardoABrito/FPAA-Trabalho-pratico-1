using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_pratico_1.model;
using NPOI.HSSF.UserModel; // Para formatos XLS (Excel 97-2003)
using NPOI.SS.UserModel;

namespace Trabalho_pratico_1
{

    public partial class Form1 : Form
    {
        private List<Vetor> listaVetor = new List<Vetor>();
        private List<DynamicAttributesClass> resultados = new List<DynamicAttributesClass>();
        private List<DynamicAttributesClass> mediaResultados = new List<DynamicAttributesClass>();
        private DataTable dataTableResultados = new DataTable();
        private DataTable dataTableMedias = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            int quantidade = 0;
            int tamanho = 0;
            bool ordenar = checkOrdenado.Checked;

            if (txtQuantidade.Text != "" && txtTamanho.Text != "")
            {
                quantidade = Convert.ToInt32(txtQuantidade.Text);
                tamanho = Convert.ToInt32(txtTamanho.Text);
            }
            if (tamanho > 0 && quantidade > 0)
            {
                for (int i = 0; i < quantidade; i++)
                {
                    listaVetor.Add(new Vetor(tamanho, ordenar));
                    Thread.Sleep(1);
                }
                lblQuantidadeVertores.Text = listaVetor.Count.ToString();
                MessageBox.Show($"Quantidade de vetores criados {listaVetor.Count}.");
            }
            else
                MessageBox.Show("Campos tem que ser maior que 0.");
        }

        private void limparCampos()
        {
            txtQuantidade.Text = "";
            txtTamanho.Text = "";
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            this.limparCampos();
            listaVetor = new List<Vetor>();
            resultados = new List<DynamicAttributesClass>();
            mediaResultados = new List<DynamicAttributesClass>();
            dataTableResultados = new DataTable();
            dataTableMedias = new DataTable();
            lblQuantidadeVertores.Text = listaVetor.Count.ToString();
            carregarResultados();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            this.aguardeAcoes();
            this.resultados = new List<DynamicAttributesClass>();

            await Task.Run(() =>
            {
                Parallel.ForEach(listaVetor, vetor =>
                {
                    DynamicAttributesClass auxclassResult = new DynamicAttributesClass();
                    auxclassResult.AddAttribute("Tamanho", vetor.getTamanho());
                    Ordenacao ordenacao;

                    foreach (string ordenacaoEscolhida in clbOrdenacoes.CheckedItems)
                    {
                        ordenacao = new Ordenacao();
                        switch (ordenacaoEscolhida)
                        {
                            case "Bolha":
                                ordenacao.Bolha(vetor.Clone().dados);
                                break;
                            case "Selecao":
                                ordenacao.Selecao(vetor.Clone().dados);
                                break;
                            case "Insercao":
                                ordenacao.Insercao(vetor.Clone().dados);
                                break;
                            case "ShellSort":
                                ordenacao.ShellSort(vetor.Clone().dados);
                                break;
                            case "QuickSort":
                                ordenacao.QuickSort(vetor.Clone().dados, 0, vetor.dados.Length - 1);
                                break;
                            case "HeapSort":
                                ordenacao.HeapSort(vetor.Clone().dados);
                                break;
                            case "MergeSort":
                                ordenacao.MergeSort(vetor.Clone().dados, 0, vetor.dados.Length - 1);
                                break;
                        }
                        auxclassResult.AddAttribute(ordenacaoEscolhida, ordenacao.stopwatch.Elapsed.TotalMilliseconds);
                        auxclassResult.AddAttribute($"{ordenacaoEscolhida}_Trocas", ordenacao.cont_t);
                    }

                    auxclassResult.AddAttribute("Ordenado", vetor.ordenado ? "Sim" : "Não");

                    lock (resultados)
                    {
                        resultados.Add(auxclassResult);
                    }
                });
            });
            this.aguardeAcoes(false);
            calcularMedia();
            this.carregarResultados();
        }

        private void carregarResultados()
        {
            // Carregar Resultados

            dataTableResultados = new DataTable();
            foreach (var dynamicObject in resultados)
            {
                foreach (var attributeName in dynamicObject.attributes.Keys)
                {
                    if (!dataTableResultados.Columns.Contains(attributeName))
                    {
                        dataTableResultados.Columns.Add(attributeName);
                    }
                }
            }

            foreach (var dynamicObject in resultados)
            {
                DataRow row = dataTableResultados.NewRow();
                foreach (var attribute in dynamicObject.attributes)
                {
                    row[attribute.Key] = dynamicObject.GetAttribute(attribute.Key);
                }
                dataTableResultados.Rows.Add(row);
            }

            dtgResultados.DataSource = dataTableResultados;

            // Carregar Media
            dataTableMedias = new DataTable();
            foreach (var dynamicObject in mediaResultados)
            {
                foreach (var attributeName in dynamicObject.attributes.Keys)
                {
                    if (!dataTableMedias.Columns.Contains(attributeName))
                    {
                        dataTableMedias.Columns.Add(attributeName);
                    }
                }
            }

            foreach (var dynamicObject in mediaResultados)
            {
                DataRow row = dataTableMedias.NewRow();
                foreach (var attribute in dynamicObject.attributes)
                {
                    row[attribute.Key] = dynamicObject.GetAttribute(attribute.Key);
                }
                dataTableMedias.Rows.Add(row);
            }

            dtgMedias.DataSource = dataTableMedias;

        }

        private void calcularMedia()
        {
            DynamicAttributesClass auxMedia = new DynamicAttributesClass();
            mediaResultados = new List<DynamicAttributesClass>();
            foreach (string ordenacaoEscolhida in clbOrdenacoes.CheckedItems)
            {
                try
                {
                    auxMedia = new DynamicAttributesClass();
                    auxMedia.AddAttribute("Nome", ordenacaoEscolhida);
                    auxMedia.AddAttribute("Tempo_Gasto", (resultados.Sum(x => (double)x.GetAttribute(ordenacaoEscolhida)) / resultados.Count).ToString("0.00000000"));
                    auxMedia.AddAttribute("Trocas", resultados.Sum(x => (int)x.GetAttribute($"{ordenacaoEscolhida}_Trocas")) / resultados.Count);
                    mediaResultados.Add(auxMedia);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void aguardeAcoes(bool ativar = true)
        {
            btnGerar.Text = ativar ? "Aguarde" : "Gerar";
            btnResetar.Text = ativar ? "Aguarde" : "Resetar";
            btnIniciar.Text = ativar ? "Aguarde" : "Iniciar";
            btnGerar.Enabled = !ativar;
            btnResetar.Enabled = !ativar;
            btnIniciar.Enabled = !ativar;
        }

        private void exportarExcel(string filePath)
        {
            IWorkbook workbook = new HSSFWorkbook();

            ISheet sheet = workbook.CreateSheet("Resultados Testes");
            ICell cell;
            IRow headerRow = sheet.CreateRow(0);

            ICellStyle headerCellStyle = workbook.CreateCellStyle();
            ICellStyle bodyCellStyle = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();

            int colunaIndex = 0;

            #region estilo celulas
            font.IsBold = true;
            font.Color = IndexedColors.White.Index;

            headerCellStyle.FillForegroundColor = IndexedColors.Grey80Percent.Index;
            headerCellStyle.FillPattern = FillPattern.SolidForeground;
            headerCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.BottomBorderColor = IndexedColors.Black.Index;
            headerCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            headerCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.TopBorderColor = IndexedColors.Black.Index;
            headerCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.BottomBorderColor = IndexedColors.Black.Index;
            headerCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.LeftBorderColor = IndexedColors.Black.Index;
            headerCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            headerCellStyle.RightBorderColor = IndexedColors.Black.Index;
            headerCellStyle.SetFont(font);

            bodyCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            bodyCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            bodyCellStyle.TopBorderColor = IndexedColors.Black.Index;
            bodyCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            bodyCellStyle.BottomBorderColor = IndexedColors.Black.Index;
            bodyCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            bodyCellStyle.LeftBorderColor = IndexedColors.Black.Index;
            bodyCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            bodyCellStyle.RightBorderColor = IndexedColors.Black.Index;
            #endregion
            // dados resultado
            for (int i = 0; i < dataTableResultados.Columns.Count; i++)
            {
                cell = headerRow.CreateCell(i);
                cell.SetCellValue(dataTableResultados.Columns[i].ColumnName);
                cell.CellStyle = headerCellStyle;
                colunaIndex = i;
            }

            for (int rowIndex = 0; rowIndex < dataTableResultados.Rows.Count; rowIndex++)
            {
                IRow dataRow = sheet.CreateRow(rowIndex + 1);

                for (int colIndex = 0; colIndex < dataTableResultados.Columns.Count; colIndex++)
                {
                    cell = dataRow.CreateCell(colIndex);
                    cell.SetCellValue(dataTableResultados.Rows[rowIndex][colIndex].ToString());
                    cell.CellStyle = bodyCellStyle;
                }
            }

            //dados média resultado
            colunaIndex += 3;
            for (int i = 0; i < dataTableMedias.Columns.Count; i++)
            {
                cell = headerRow.CreateCell(colunaIndex+i);
                cell.SetCellValue(dataTableMedias.Columns[i].ColumnName);
                cell.CellStyle = headerCellStyle;
            }

            for (int rowIndex = 0; rowIndex < dataTableMedias.Rows.Count; rowIndex++)
            {
                IRow dataRow = sheet.CreateRow(rowIndex + 1);

                for (int colIndex = 0; colIndex < dataTableMedias.Columns.Count; colIndex++)
                {
                    cell = dataRow.CreateCell(colunaIndex + colIndex);
                    cell.SetCellValue(dataTableResultados.Rows[rowIndex][colIndex].ToString());
                    cell.CellStyle = bodyCellStyle;
                }
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }

            MessageBox.Show("Dados exportados com sucesso para o Excel!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InfoSistema infoSistema = new InfoSistema();
            lblInfoSistema.Text = $"Modelo do Processador: {infoSistema.processorModel}\n" +
                                  $"Velocidade do Processador: {infoSistema.processorSpeed} MHz\n" +
                                  $"Quantidade de Memória RAM: {infoSistema.totalMemory / (1024 * 1024)} MB\n" +
                                  $"Nome do Sistema Operacional: {infoSistema.osName}\n" +
                                  $"Versão do Sistema Operacional: {infoSistema.osVersion}\n";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos do Excel (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                exportarExcel(saveFileDialog.FileName);
        }
    }
}