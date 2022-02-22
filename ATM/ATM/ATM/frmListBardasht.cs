using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ATM
{
    public partial class frmListBardasht : Form
    {

        SqlConnection atmdatabase = new SqlConnection("Data source=(Local);initial catalog=ATM; integrated security=true");
        SqlCommand cmd = new SqlCommand();

        //in 2 khat Baraye etesal Database be Barnameh Mibashad.
        void Display()
        {
            DataSet set = new DataSet();
            SqlDataAdapter sdd = new SqlDataAdapter();
            sdd.SelectCommand = new SqlCommand();
            sdd.SelectCommand.Connection = atmdatabase;
            sdd.SelectCommand.CommandText = "Select * from Wishlist Where Date Between '" + msksrchdate1.Text + "' AND '" + msksrchdate2.Text + "'";
            sdd.Fill(set, "Wishlist");
            dgvBardash.DataSource = set;
            dgvBardash.DataMember = "Wishlist";
            dgvBardash.Columns[0].HeaderText = "کد";
            dgvBardash.Columns[1].HeaderText = "نام حساب (بانک)";
            dgvBardash.Columns[2].HeaderText = "شماره کارت";
            dgvBardash.Columns[3].HeaderText = "مبلغ واریزی";
            dgvBardash.Columns[4].HeaderText = "تاریخ ";
          
            // Bakhsh Jostojoo Va Namayesh Etela'at
            //____________________________________________
        }
        public frmListBardasht()
        {
            InitializeComponent();
        }
        private void frmListBardasht_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            msksrchdate1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msksrchdate2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            Display();
        }

        private void msksrchdate1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void msksrchdate1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void msksrchdate2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
}
