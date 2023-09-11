using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico_1.model
{
    internal class Ordenacao
    {
        // TODO: contador de comparações e trocas
        // TODO: declarar demais métodos de ordenação
        public int cont_c { get; set; }
        public int cont_t { get; set; }
        public Stopwatch stopwatch { get; }

        public Ordenacao()
        {
            this.cont_c = 0;
            this.cont_t = 0;
            this.stopwatch = new Stopwatch();
        }
        public void Bolha(int[] vet)
        {
            stopwatch.Start();
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                for (j = vet.Length - 1; j > i; j--)
                {
                    cont_c++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                        cont_t++;
                    }
                }
            }
            stopwatch.Stop();
        }

        public void Selecao(int[] vet)
        {
            stopwatch.Start();
            int i, j, min, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < vet.Length; j++)
                {
                    cont_c++;
                    if (vet[j] < vet[min])
                    {
                        min = j;
                    }
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;
                cont_t++;
            }
            stopwatch.Stop();   
        }

        public void Insercao(int[] vet)
        {
            stopwatch.Start();
            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                j = i - 1;
                while (j >= 0 && temp < vet[j])
                {
                    cont_c++;
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = temp;
                cont_t++;
            }
            stopwatch.Stop();
        }

        public void ShellSort(int[] vet)
        {
            stopwatch.Start();
            int i, j, x, n;
            int h = 1;
            n = vet.Length;
            do
            {
                h = h * 3 + 1;
            } while (h <= n);
            do
            {
                h /= 3;
                for (i = h; i < n; i++)
                {
                    x = vet[i];
                    j = i;
                    while (j > (h - 1) && vet[j - h] > x)
                    {
                        cont_c++;
                        vet[j] = vet[j - h];
                        j -= h;
                    }
                    vet[j] = x;
                    cont_t++;
                }
            } while (h != 1);
            stopwatch.Stop();
        }

        #region QuickSort
        public void QuickSort(int[] vet, int esq, int dir)
        {
            stopwatch.Start();
            QuickSortMetodo(vet, esq, dir);
            stopwatch.Stop();

        }
        private void QuickSortMetodo(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) i++;
                while (x < vet[j]) j--;
                cont_c++;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                    cont_t++;
                }
            } while (i <= j);
            if (esq < j) QuickSortMetodo(vet, esq, j);
            if (i < dir) QuickSortMetodo(vet, i, dir);
        }
        #endregion

        #region HeapSort
        public void HeapSort(int[] v)
        {
            stopwatch.Start();
            constroiMaxHeap(v);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--)
            {
                troca(v, i, 0);
                refaz(v, 0, --n);
            }
            stopwatch.Stop();
        }

        private void constroiMaxHeap(int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
                refaz(v, i, v.Length);

        }
        private void refaz(int[] vetor, int pos, int tamanhoDoVetor)
        {

            int max = 2 * pos + 1, right = max + 1;
            if (max < tamanhoDoVetor)
            {
                cont_c++;
                if (right < tamanhoDoVetor && vetor[max] < vetor[right])
                    max = right;

                cont_c++;
                if (vetor[max] > vetor[pos])
                {
                    troca(vetor, max, pos);
                    refaz(vetor, max, tamanhoDoVetor);
                }
            }
        }

        public void troca(int[] v, int j, int aposJ)
        {
            cont_t++;
            int aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
        }
        #endregion

        #region MergeSort
        public void MergeSort(int[] v, int i, int j)
        {
            stopwatch.Start();
            MergeSortMetodo(v, i, j);
            stopwatch.Stop();
        }
        private void MergeSortMetodo(int[] v, int i, int j)
        {
            if (i < j)
            {
                cont_c++;
                int m = (i + j) / 2;
                MergeSortMetodo(v, i, m);
                MergeSortMetodo(v, m + 1, j);
                merge(v, i, m, j); // intercala v[i..m] e v[m+1..j] em v[i..j] 
            }
        }
        private void merge(int[] v, int i, int m, int j)
        {
            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
                temp[k - i] = v[k];
            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                if (temp[esq] <= v[dir])
                    v[i++] = temp[esq++];
                else
                    v[i++] = v[dir++];
                cont_c++;
                cont_t++;
            }
            while (esq < k)
                v[i++] = temp[esq++];
        }
        #endregion
    }
}
