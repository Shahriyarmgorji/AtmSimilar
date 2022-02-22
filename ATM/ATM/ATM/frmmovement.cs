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
    public partial class frmmovement : Form
    {
        public frmmovement()
        {
            InitializeComponent();
        }

        SqlConnection atmdatabase = new SqlConnection("Data source=(Local);initial catalog=ATM; integrated security=true");
        SqlCommand cmd = new SqlCommand();

        //in 2 khat Baraye etesal Database be Barnameh Mibashad.
        void Display()
        {
            DataSet set = new DataSet();
            SqlDataAdapter sdd = new SqlDataAdapter();
            sdd.SelectCommand = new SqlCommand();
            sdd.SelectCommand.Connection = atmdatabase;
            sdd.SelectCommand.CommandText = "Select * from movement Where Date Between '" + msksrchdate1.Text + "' AND '" + msksrchdate2.Text + "'";
            sdd.Fill(set, "movement");
            dgvmovement.DataSource = set;
            dgvmovement.DataMember = "movement";
            dgvmovement.Columns[0].HeaderText = "کد";
            dgvmovement.Columns[1].HeaderText = "کارت مقصد";
            dgvmovement.Columns[2].HeaderText = "نام بانک";
            dgvmovement.Columns[3].HeaderText = "صاحب حساب";
            dgvmovement.Columns[4].HeaderText = " مبلغ انتقال";
            dgvmovement.Columns[5].HeaderText = "تاریخ";
            dgvmovement.Columns[6].HeaderText = "ساعت";
            // Bakhsh Jostojoo Va Namayesh Etela'at
            //____________________________________________
        }
        private void frmmovement_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            msksrchdate1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msksrchdate2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            Display();
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
