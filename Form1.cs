using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercíciosDeFixação2
{
    public partial class Form1 : Form
    {
        private OpenFileDialog novoArquivo = new OpenFileDialog();
        private SaveFileDialog salvarNovoArquivo = new SaveFileDialog();

        SqlConnection conn = new SqlConnection("Data Source=OSA0625215W10-1;Initial Catalog=FIXACAO_000;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            CarregarLista();
        }
        private void CarregarLista()
        {
            listBoxNome.Items.Clear();
            listBoxValor.Items.Clear();
            listBoxNumero.Items.Clear();
            listBoxItem.Items.Clear();

            conn.Open();
            comando.CommandText = "select * from Exercicio2";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBoxNome.Items.Add(dr[1].ToString());
                    listBoxValor.Items.Add(dr[2].ToString());
                    listBoxNumero.Items.Add(dr[3].ToString());
                    listBoxItem.Items.Add(dr[4].ToString());
                }
            }
            conn.Close();
        }

        private void ListBoxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBoxNome.SelectedIndex = l.SelectedIndex;
                listBoxValor.SelectedIndex = l.SelectedIndex;
                listBoxNumero.SelectedIndex = l.SelectedIndex;
                listBoxItem.SelectedIndex = l.SelectedIndex;
            }
        }

        private void ListBoxValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBoxNome.SelectedIndex = l.SelectedIndex;
                listBoxValor.SelectedIndex = l.SelectedIndex;
                listBoxNumero.SelectedIndex = l.SelectedIndex;
                listBoxItem.SelectedIndex = l.SelectedIndex;
            }
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            if (BtnInserir.Text == "Inserir Dados")
            {
                if (novoArquivo.ShowDialog() != DialogResult.OK)
                    return;

                if (!novoArquivo.FileName.Contains(".csv"))
                    return;
                string caminho = novoArquivo.FileName;
                string textoLido;
                
                textoLido = File.ReadAllText(caminho);

                int i = 0;
                listBoxNome.Items.Clear();
                foreach (var linha in textoLido.Split('\n'))
                {
                    if (linha == "" || linha == "\r") break;
                    if (i != 0)
                    {
                        string[] tratamento = linha.Split(';');
                        Pessoa ps = new Pessoa(tratamento[0], tratamento[1], tratamento[2], tratamento[3]);
                        listBoxNome.Items.Add(ps);
                    }
                    i++;
                }
                BtnInserir.Text = "Salvar Arquivo";
            }

            else
            {
                string txt = "Nome,Sobrenome,Data de Nascimento;Telefone;Email\n";
                foreach (Pessoa pessoa in listBoxNome.Items)
                {
                    txt += pessoa.nomeProduto + ";";
                    txt += pessoa.valorProduto + ";";
                    txt += pessoa.mediaValor + ";";
                    txt += pessoa.mediaItem + "\n";
                }
                txt = txt.Substring(0, txt.Length - 5);
                salvarNovoArquivo.Filter = "Arquivo CSV|*.csv";
                salvarNovoArquivo.Title = "Salvar Arquivo";
                if (salvarNovoArquivo.ShowDialog() != DialogResult.OK && salvarNovoArquivo.FileName == null) return;
                if (salvarNovoArquivo.ShowDialog() != DialogResult.Cancel) return;

                try
                {
                    FileStream abrirArquivo = (FileStream)salvarNovoArquivo.OpenFile();
                    StreamWriter salvandoArquivo = new StreamWriter(abrirArquivo);

                    salvandoArquivo.WriteLine(txt);
                    salvandoArquivo.Close();
                    abrirArquivo.Close();
                    BtnInserir.Text = "Inserir Dados";
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'fIXACAO_000DataSet.EXERCICIO1'. Você pode movê-la ou removê-la conforme necessário.
            this.eXERCICIO1TableAdapter.Fill(this.fIXACAO_000DataSet.EXERCICIO1);

        }
    }
}
