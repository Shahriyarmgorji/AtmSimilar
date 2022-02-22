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
    public partial class frm_New_Account : Form
    {
        public frm_New_Account()
        {
            InitializeComponent();
        }

        //___________________________________________________________________________
        SqlConnection atmdatabase = new SqlConnection("Data source=(Local);initial catalog=ATM; integrated security=true");
        SqlCommand cmd = new SqlCommand();

        //in 2 khat Baraye etesal Database be Barnameh Mibashad.
        void Display()
        {
            DataSet set = new DataSet();
            SqlDataAdapter sdd = new SqlDataAdapter();
            sdd.SelectCommand = new SqlCommand();
            sdd.SelectCommand.Connection = atmdatabase;
            sdd.SelectCommand.CommandText = "Select * from Account";
            sdd.Fill(set, "Account");
            Dgv_Account.DataSource = set;
            Dgv_Account.DataMember = "Account";
            Dgv_Account.Columns[0].HeaderText = "کد";
            Dgv_Account.Columns[1].HeaderText = "نام حساب";
            Dgv_Account.Columns[2].HeaderText = "شماره کارت";
            Dgv_Account.Columns[3].HeaderText = "شماره حساب";
            Dgv_Account.Columns[4].HeaderText = "موجودی کارت";
            Dgv_Account.Columns[5].HeaderText = "نام صاحب حساب";
            Dgv_Account.Columns[6].HeaderText = "تاریخ انقضا";
            Dgv_Account.Columns[7].HeaderText = "رمز عبور";
        }
        //___________________________________________________________________________
        private void frm_New_Account_Load(object sender, EventArgs e)
        {
            Display();
        }

        //___________________________________________________________________________
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TxtCard.Text.Length == 16)
            {

                Display();
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "insert Into Account(TXTBank,Id_Card,Id_Account,Card_Inventory,Name_Bank_Account_Holder,Date,PassWord)values(@a,@b,@c,@d,@e,@f,@g)";
                cmd.Parameters.AddWithValue("@a", TxtName.Text);
                cmd.Parameters.AddWithValue("@b", TxtCard.Text);
                cmd.Parameters.AddWithValue("@c", Txt_Account.Text);
                cmd.Parameters.AddWithValue("@d", TxtInventory.Text);
                cmd.Parameters.AddWithValue("@e", TxtAccount_Holder.Text);
                cmd.Parameters.AddWithValue("@f", MSKTime.Text);
                cmd.Parameters.AddWithValue("@g", txtPassword.Text);
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                MessageBox.Show("حساب با موفقیت ثبت شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("شماره کارت معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Az Khate 50 ta 67 baraye sabt Va zakhire sazi Hesab Dar Database Mibashad.
        //___________________________________________________________________________
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TxtCard.Text.Length == 16)
            {
                int Del = Convert.ToInt32(Dgv_Account.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "Delete from Account Where id=@N";
                cmd.Parameters.AddWithValue("@N", Del);
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                Display();
                MessageBox.Show("حساب با موفقیت حذف شد", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("شماره کارت معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Az Khate 70 ta 82 baraye Hazf Hesab Dar Database Mibashad.
        //___________________________________________________________________________
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TxtCard.Text.Length == 16)
            {
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "Update Account Set TXTBank='" + TxtName.Text + "',Id_Card='" + TxtCard.Text + "',Id_Account='" + Txt_Account.Text + "',Card_Inventory='" + TxtInventory.Text + "',Name_Bank_Account_Holder='" + TxtAccount_Holder.Text + "',Date='" + MSKTime.Text + "',PassWord='" + txtPassword.Text + "' where ID=" + TXTCode.Text;
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                Display();
                MessageBox.Show("حساب با موفقیت ویرایش شد");
            }
            else
            {
                MessageBox.Show("شماره کارت معتبر نیست.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Az Khate 85 ta 95 baraye Hazf Hesab Dar Database Mibashad.
        //___________________________________________________________________________
        private void Dgv_Account_MouseUp(object sender, MouseEventArgs e)
        {
            TXTCode.Text = Dgv_Account[0, Dgv_Account.CurrentRow.Index].Value.ToString();
            TxtName.Text = Dgv_Account[1, Dgv_Account.CurrentRow.Index].Value.ToString();
            TxtCard.Text = Dgv_Account[2, Dgv_Account.CurrentRow.Index].Value.ToString();
            Txt_Account.Text = Dgv_Account[3, Dgv_Account.CurrentRow.Index].Value.ToString();
            TxtInventory.Text = Dgv_Account[4, Dgv_Account.CurrentRow.Index].Value.ToString();
            TxtAccount_Holder.Text = Dgv_Account[5, Dgv_Account.CurrentRow.Index].Value.ToString();
            MSKTime.Text = Dgv_Account[6, Dgv_Account.CurrentRow.Index].Value.ToString();
            txtPassword.Text = Dgv_Account[7, Dgv_Account.CurrentRow.Index].Value.ToString();
            //Jahat Namayesh Etela'at Hesab dar safhe Form
            //_____________________________________________________________________________
        }

        private void TXTId_Card_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgv_Account_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ForeColor = Color.Black;
        }

        private void TXTCode_TextChanged(object sender, EventArgs e)
        {

        }
        //Baraye Namayesh Hesab Ha Dar Payin Form....
        //___________________________________________________________________________
    }
}
