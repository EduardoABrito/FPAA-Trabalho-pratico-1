using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_pratico_1.model;

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
                    Thread.Sleep(1);
                    listaVetor.Add(new Vetor(tamanho, ordenar));

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
            lblQuantidadeVertores.Text = listaVetor.Count.ToString();
            listaVetor = new List<Vetor>();
            resultados = new List<DynamicAttributesClass>();
            mediaResultados = new List<DynamicAttributesClass>();
            dataTableResultados = new DataTable();
            dataTableMedias = new DataTable();
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

        private void exportarExcel()
        {

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
    }
}