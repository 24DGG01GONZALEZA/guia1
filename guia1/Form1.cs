using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guia1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAB-A-PC20\SQLEXPRESS; Initial Catalog=Productos; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void obtenerregistros()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM postres", "server=LAB-A-PC20\\SQLEXPRESS; database = Productos; Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "nombre");
            dataGridView1.DataSource = ds.Tables["nombre"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=LAB-A-PC20\SQLEXPRESS;Initial Catalog=Productos; Integrated Security=True");
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("llena las celdas primero");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("insert into postres(nombre,precio,stock)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", conn);
                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Datos ingresados correctamente");
                    obtenerregistros();
                }
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error de SQL verificar:"+ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerregistros();
        }
    }
}
