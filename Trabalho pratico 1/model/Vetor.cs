﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_pratico_1.model
{
    internal class Vetor
    {
        public int[] dados { get; }
        public bool ordenado { get; }

        public Vetor(int tamanho,bool ordenado = false) {
            this.dados = new int[tamanho];
            this.ordenado = ordenado;
            popularVetor();
        }
        private Vetor(int[] dados, bool ordenado) {
            this.dados = dados;
            this.ordenado = ordenado;
        }

        public Vetor Clone()
        {
            return new Vetor(this.dados, this.ordenado );
        }

        public double testeOrdenarQuicksort()
        {

            return 0.1;
        }

        public double testeOrdenarMergeSort()
        {
            return 0.2;
        }

        public void popularVetor()
        {
            Random random = new Random();
            for (int i = 0; i < this.dados.Length; i++)
            {
                this.dados[i] = ordenado ? i + 1 : random.Next(1, 100);
            }
        }

        #region Get - Set
        public int getTamanho()
        {
            return this.dados.Length;
        }
        #endregion
    }
}
