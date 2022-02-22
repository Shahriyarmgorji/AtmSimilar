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
    public partial class BankCards : Form
    {
        public BankCards()
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
            sdd.SelectCommand.CommandText = "Select * from BankCard";
            sdd.Fill(set, "BankCard");
            Dgv_Card.DataSource = set;
            Dgv_Card.DataMember = "BankCard";
            Dgv_Card.Columns[0].HeaderText = "کد";
            Dgv_Card.Columns[1].HeaderText = "نام حساب";
            Dgv_Card.Columns[2].HeaderText = "شماره کارت";
            Dgv_Card.Columns[3].HeaderText = "نام صاحب حساب";
            // Baraye Namayesh Atela'at dakhael DataBase Estefadeh Mishavad

        }
        private void BankCard_Load(object sender, EventArgs e)
        {
            Display();
            //____________________________________________________
            TxtCode.BackColor = Color.White;
            TxtCode.ForeColor = Color.Black;
            //____________________________________________________
            TxtName.BackColor = Color.White;
            TxtName.ForeColor = Color.Black;
            //____________________________________________________
            TxtCard.BackColor = Color.White;
            TxtCard.ForeColor = Color.Black;
            //____________________________________________________
            TxtAccount_Holder.BackColor = Color.White;
            TxtAccount_Holder.ForeColor = Color.Black;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TxtCard.Text.Length == 16)
            {
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "insert Into BankCard(NameBank,IDCard,Name_Bank_Account_Holder)values(@a,@b,@c)";
                cmd.Parameters.AddWithValue("@a", TxtName.Text);
                cmd.Parameters.AddWithValue("@b", TxtCard.Text);
                cmd.Parameters.AddWithValue("@c", TxtAccount_Holder.Text);
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                MessageBox.Show("مشخصات کارت بانکی با موفقیت ثبت شد.", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Display();
            }
            else
            {

                MessageBox.Show("شماره کارت معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Baraye sabt Moshakhasate Kart Banki va Kart Be Kart Kardan Mablasgh Mablasgh Baraye Kart Morede Nazar
            //____________________________________________________________________
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TxtCard.Text.Length == 16)
            {
                int Del = Convert.ToInt32(Dgv_Card.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "Delete From BankCard where ID=@N";
                cmd.Parameters.AddWithValue("@N", Del);
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                MessageBox.Show(".مشخصات کارت بانکی با موفقیت حذف شد", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Display();
            }
            else
            {

                MessageBox.Show("شماره کارت معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Baraye Hazf Moshakhasate Kart Banki va Kart Be Kart Kardan Mablasgh Baraye Kart Morede Nazar
            //____________________________________________________________________
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TxtCard.Text.Length == 16)
            {
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "Update BankCard set NameBank='" + TxtName.Text + "',IDCard='" + TxtCard.Text + "',Name_Bank_Account_Holder='" + TxtAccount_Holder.Text + "' where ID=" + TxtCode.Text;
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                Display();
                MessageBox.Show(".مشخصات کارت بانکی با موفقیت ویرایش شد", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("شماره کارت معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void Dgv_Card_MouseUp(object sender, MouseEventArgs e)
        {
            TxtCode.Text = Dgv_Card[0, Dgv_Card.CurrentRow.Index].Value.ToString();
            TxtName.Text = Dgv_Card[1, Dgv_Card.CurrentRow.Index].Value.ToString();
            TxtCard.Text = Dgv_Card[2, Dgv_Card.CurrentRow.Index].Value.ToString();
            TxtAccount_Holder.Text = Dgv_Card[3, Dgv_Card.CurrentRow.Index].Value.ToString();
            //Baraye Entekhab Kart Mirede Nazar Jahat Virayesh ya Hazf
            //______________________________________________________

        }

        private void Dgv_Card_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
