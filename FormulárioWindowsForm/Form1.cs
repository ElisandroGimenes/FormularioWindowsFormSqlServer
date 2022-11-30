using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FormulárioWindowsForm
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTelefone_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //String conexão com banco de dados
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CCH60LK6;Initial Catalog=teste;Integrated Security=True");

            //String de inserção no banco de dados
            string sql = "INSERT INTO pessoas (id, nome, email, telefone) VALUES (@id, @nome, @email, @telefone)";
            Random numeroID = new Random();
            numeroID.Next();

            try
            {
                //Cria um objeto do tipo comando passando com parâmetros as strings sql e conn 
                SqlCommand c = new SqlCommand(sql, conn);

                //Insere os dados  da txtBox no comando sql
                c.Parameters.Add(new SqlParameter("@id", numeroID.Next()));
                c.Parameters.Add(new SqlParameter("@nome", this.txtNome.Text));
                c.Parameters.Add(new SqlParameter("@email", this.txtEmail.Text));
                c.Parameters.Add(new SqlParameter("@telefone", this.txtTelefone.Text));

                //Abre a conexão com o banco
                conn.Open();

                //Executa o comando Sql
                c.ExecuteNonQuery();

                //Fecha a conexão com o banco
                conn.Close();

                MessageBox.Show("Registro salvo com sucesso!");

            } catch (SqlException ex) 
            { 
                MessageBox.Show("Ocorreu o erro de conexão: " + ex);
            }
            finally
            { 
                conn.Close(); 
            }
        }
    }
}
