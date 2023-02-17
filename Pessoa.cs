using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercíciosDeFixação2
{
    class Pessoa
    {
        private string NomeProduto;
        private string ValorProduto;
        private string MediaValor;
        private string MediaItem;
        public override string ToString()
        {
            return nomeProduto;
        }
        public string nomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public string valorProduto
        {
            get { return valorProduto; }
            set { valorProduto = value; }
        }

        public string mediaValor
        {
            get { return mediaValor; }
            set { mediaValor = value; }
        }

        public string mediaItem
        {
            get { return mediaItem; }
            set { mediaItem = value; }
        }

        public Pessoa(string NomeProduto, string ValorProduto, string MediaValor, string MediaItem)
        {
            this.NomeProduto = NomeProduto;
            this.ValorProduto = ValorProduto;
            this.MediaValor = MediaValor;
            this.MediaItem = MediaItem;
        }
    }
}
