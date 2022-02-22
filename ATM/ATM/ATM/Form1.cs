using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stimulsoft.Report;
using System.Data.SqlClient;
namespace ATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection atmdatabase = new SqlConnection("Data source=(Local);initial catalog=ATM; integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public void Back()
        {
            stcmoneytransfer.SelectedTab = Bankingoperations;
            //Bazgasht be marhale ghabl
        }
        void Displaymove()
        {
            DataSet set = new DataSet();
            SqlDataAdapter sdd = new SqlDataAdapter();
            sdd.SelectCommand = new SqlCommand();
            sdd.SelectCommand.Connection = atmdatabase;
            sdd.SelectCommand.CommandText = "Select * from movement Where Date Between '" + msksrchdate1.Text + "' AND '" + msksrchdate2.Text + "'";
            sdd.Fill(set, "movement");
            dgvmovement2.DataSource = set;
            dgvmovement2.DataMember = "movement";
            dgvmovement2.Columns[0].HeaderText = "کد";
            dgvmovement2.Columns[1].HeaderText = "کارت مقصد";
            dgvmovement2.Columns[2].HeaderText = "نام بانک";
            dgvmovement2.Columns[3].HeaderText = "صاحب حساب";
            dgvmovement2.Columns[4].HeaderText = " مبلغ انتقال";
            dgvmovement2.Columns[5].HeaderText = "تاریخ";
            dgvmovement2.Columns[6].HeaderText = "ساعت";
            // Bakhsh Jostojoo Va Namayesh Etela'at
            //____________________________________________
        }

        void Displaybardasht()
        {
            DataSet set = new DataSet();
            SqlDataAdapter sdd = new SqlDataAdapter();
            sdd.SelectCommand = new SqlCommand();
            sdd.SelectCommand.Connection = atmdatabase;
            sdd.SelectCommand.CommandText = "Select * from Wishlist Where Date Between '" + msksrchdate1.Text + "' AND '" + msksrchdate2.Text + "'";
            sdd.Fill(set, "Wishlist");
            dgvwishlist2.DataSource = set;
            dgvwishlist2.DataMember = "Wishlist";
            dgvwishlist2.Columns[0].HeaderText = "کد";
            dgvwishlist2.Columns[1].HeaderText = "نام حساب (بانک)";
            dgvwishlist2.Columns[2].HeaderText = "شماره کارت";
            dgvwishlist2.Columns[3].HeaderText = "مبلغ واریزی";
            dgvwishlist2.Columns[4].HeaderText = "تاریخ ";

            // Bakhsh Jostojoo Va Namayesh Etela'at
            //____________________________________________
        }
        void Displayvariz()
        {
            DataSet set = new DataSet();
            SqlDataAdapter sdd = new SqlDataAdapter();
            sdd.SelectCommand = new SqlCommand();
            sdd.SelectCommand.Connection = atmdatabase;
            sdd.SelectCommand.CommandText = "Select * from Deposit Where Date Between '" + msksrchdate1.Text + "' AND '" + msksrchdate2.Text + "'";
            sdd.Fill(set, "Deposit");
            dgvvariz.DataSource = set;
            dgvvariz.DataMember = "Deposit";
            dgvvariz.Columns[0].HeaderText = "کد";
            dgvvariz.Columns[1].HeaderText = "نام حساب (بانک)";
            dgvvariz.Columns[2].HeaderText = "شماره کارت";
            dgvvariz.Columns[3].HeaderText = "مبلغ واریزی";
            dgvvariz.Columns[4].HeaderText = "تاریخ مبلغ";
            dgvvariz.Columns[5].HeaderText = "توضیحات";
            // Bakhsh Jostojoo Va Namayesh Etela'at
            //____________________________________________
        }

        //etesal Be Database
        //__________________________________________________________________________________________
        static string BankName, IdCard, Date, NamePerson;
        static int Depositm;//Mablagh varizi
        static int DepositNew;
        static string Accountdestination, AccountdestinationHolder, idcarddestination;


        //__________________________________________________________________________________________
        private void EXIT_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //ba click bar dokmeh enseraf Be safheh asli montaghel mishavim .
            //_____________________________________________________________________________________

        }

        private void Input_Card_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = language;
            //pas az Vared kardan Kart be safheh entekhab zaban Pish Miravim .
            //_____________________________________________________________________________________
        }

        private void Persian_Click(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"));
            stcmoneytransfer.SelectedTab = PasswordTab;// passwordtab mah Vorood password Mibashad.
            //Zaban Voroodi be Farsi taghir mikonad .
            //_____________________________________________________________________________________

        }

        private void English_Click(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            stcmoneytransfer.SelectedTab = PasswordTab;// passwordtab mah Vorood password Mibashad.
            //Zaban Voroodi be englisi taghir mikonad .
            //_____________________________________________________________________________________

        }

        private void InputPass_Click(object sender, EventArgs e)
        {
            atmdatabase.Close();
            SqlDataReader DR;
            cmd = new SqlCommand();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "Select * from Account where PassWord=@N";
            cmd.Parameters.AddWithValue("@N", txtpassword.Text);
            atmdatabase.Open();
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                BankName = DR["TXTBank"].ToString();
                NamePerson = DR["Name_Bank_Account_Holder"].ToString();
                IdCard = DR["Id_Card"].ToString();
                Depositm = Convert.ToInt32(DR["Card_Inventory"]);
            }
            else
            {
                MessageBox.Show("رمز عبور اشتباه است.");
                txtpassword.Text = "";
                txtpassword.Focus();
                return;
            }
            atmdatabase.Close();
            stcmoneytransfer.SelectedTab = Bankingoperations;

            //Dar Soorate Dorost Boodan Ramz amaliyat banki edameh miyabad 
            // Dar Gheyre In Soorat Mojadad Ramz ra Vared Mikonid ...
            //_____________________________________________________________________________________
        }

        private void Cancellang_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //ba click bar dokmeh enseraf Be safheh asli montaghel mishavim .
            //_____________________________________________________________________________________
        }
        private void Cancel01_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //ba click bar dokmeh enseraf Be safheh asli montaghel mishavim .
        }
        //_____________________________________________________________________________________
        private void buttonX1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                this.Opacity -= 0.01;
                System.Threading.Thread.Sleep(11);
            }
            Application.Exit();
        }
        //In Code Baraye Khrooj Az Narm afzar Nevashte Shode ast Va Marboot be Dokmeye Khrooj Mibashad
        //____________________________________________________________________________
        private void Hide_Click(object sender, EventArgs e)
        {
            this.Size = new Size(846, 535);
            Hide.Visible = false;
            Show04.Visible = true;
            //baraye makhfi kardan dokmeh ha estefadeh mishavad
            //_______________________________________________________________
        }
        private void Hide03_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1001, 535);
            Hide03.Visible = false;
            Hide.Visible = true;
        }
        // baraye Makhfi Kardan gozineh haye tarif kart va tarif hesab Mibashad .
        //________________________________________________________________________
        private void Show04_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1001, 535);
            Hide.Visible = true;
            Show04.Visible = false;
            // baraye namayesh gozineh haye tarif kart va tarif hesab Mibashad .

        }
        //________________________________________________________________________
        private void New_account_Click(object sender, EventArgs e)
        {
            new frm_New_Account().ShowDialog();

            //Baraye Vorood Be ghesmate Tarif Hesab Mibashad.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new FrmSplash().ShowDialog();

            txtoldpass.BackColor = Color.White;
            txtoldpass.ForeColor = Color.Black;
            //_______________________________________
            txtnewpass.BackColor = Color.White;
            txtnewpass.ForeColor = Color.Black;
            //______________________________________________________________
            this.Size = new Size(846, 535);// taghir size Safheh
            //______________________________________________________________
            txtpassword.BackColor = Color.White;
            txtpassword.ForeColor = Color.Black;
            //______________________________________________________________
            TxtWishlist.BackColor = Color.White;
            TxtWishlist.ForeColor = Color.Black;
            //______________________________________________________________
            txtidcard.BackColor = Color.White;
            txtidcard.ForeColor = Color.Black;
            //______________________________________________________________
            txtdepisitamount.BackColor = Color.White;
            txtdepisitamount.ForeColor = Color.Black;
            //______________________________________________________________
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            Date = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msksrchdate1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            msksrchdate2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            //______________________________________________________________
            Displaymove();
            Displaybardasht();
            Displayvariz();
        }

        private void Bank_Card_Click(object sender, EventArgs e)
        {
            new BankCards().ShowDialog();

            //Baraye Vorood Be ghesmate Tarif Hesab Mibashad.
        }

        private void Withdrawal_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = InventoryWithdrawal;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   //string MablaghHesab;
            int MablaghBardasht;
            atmdatabase.Open();
            //SqlCommand sqlcmd = new SqlCommand("select Card_Inventory From Account Where Id_Card='" + txtidcars.Text + "'", atmdatabase);
            //MablaghHesab = Convert.ToString((int)sqlcmd.ExecuteScalar());

            MablaghBardasht = Convert.ToInt32(TxtWishlist.Text);
            if (Depositm < MablaghBardasht)
            {
                MessageBox.Show("موجودی کافی نیست");

            }
            else
            {
                int Sum = Depositm - MablaghBardasht;
                string UpdateMablagh = "Update Account Set Card_Inventory='" + Sum + "' Where Id_Card='" + IdCard + "' ";
                SqlCommand com = new SqlCommand(UpdateMablagh, atmdatabase);
                com.ExecuteNonQuery();
                atmdatabase.Close();
                //Bardasht mablagh Az hesab...
                //__________________________________________________________________________________________________________
                cmd.Parameters.Clear();
                cmd.Connection = atmdatabase;
                cmd.CommandText = "insert into Wishlist (NameBank,IdCard,Depositm,Date,HESAB)Values(@a,@b,@c,@d,@E)";
                cmd.Parameters.AddWithValue("@a", BankName);
                cmd.Parameters.AddWithValue("@b", IdCard);
                cmd.Parameters.AddWithValue("@c", TxtWishlist.Text);
                cmd.Parameters.AddWithValue("@d", Date);
                cmd.Parameters.AddWithValue("@E", TxtWishlist.Text);
                atmdatabase.Open();
                cmd.ExecuteNonQuery();
                atmdatabase.Close();
                MessageBox.Show("برداشت وجه انجام شد .");
            }
            //______________________________________________________________
            int DepositN;
            atmdatabase.Close();
            SqlDataReader DR;
            cmd = new SqlCommand();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "Select Card_Inventory from Account where PassWord=@N";
            cmd.Parameters.AddWithValue("@N", txtpassword.Text);
            atmdatabase.Open();
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                DepositN = Convert.ToInt32(DR["Card_Inventory"]);
            }
            else
            {
                return;
            }
            atmdatabase.Close();
            stcmoneytransfer.SelectedTab = Bankingoperations;
            //check kardan bardasht mablash az hesab
            //______________________________________________________________
            StiReport Report = new StiReport();
            Report.Load("Report/rptwishlist.mrt");
            Report.Compile();
            Report["BankName"] = BankName;
            Report["IDCard"] = IdCard;
            Report["NamePerson"] = NamePerson;
            Report["Bardasht"] = Convert.ToInt32(TxtWishlist.Text);
            Report["Deposit"] = Convert.ToInt32(DepositN);
            Report["Time"] = lbltime.Text;
            Report["Date"] = Date;

            Report.ShowWithRibbonGUI();

            // Chap Resid Bardasht
        }

        private void lbl10000_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl10000.Text;
            // be arzaesh 10 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            // Daryaft Card va Bazgasht Be Safhe Aval
        }
        private void LblTooman_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl10000.Text;

            // be arzaesh 10 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void lbl20000_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl20000.Text;

            // be arzaesh 20 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void labelX5_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl20000.Text;

            // be arzaesh 20 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void lbl50000_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl50000.Text;

            // be arzaesh 50 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void labelX1_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl50000.Text;
            // be arzaesh 50 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void lbl100000_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl100000.Text;
            // be arzaesh 100 hezar Tooman mablagh bardasht Mishavad ....

        }

        private void labelX2_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl100000.Text;

            // be arzaesh 100 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void lbl200000_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl200000.Text;

            // be arzaesh 200 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void labelX3_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl200000.Text;

            // be arzaesh 200 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void lbl75000_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl75000.Text;

            // be arzaesh 75 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void labelX4_Click(object sender, EventArgs e)
        {
            TxtWishlist.Text = lbl75000.Text;
            // be arzaesh 75 hezar Tooman mablagh bardasht Mishavad ....
        }

        private void lblListReport_Click(object sender, EventArgs e)
        {
            new frmListBardasht().ShowDialog();
            //Namayesh safhe gozaresh bardashtmablagh
        }

        private void Money_transfer_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = Moneytransfor;
            //enteghal Be mahal kart be kart kardan puol
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //enseraf Va daryaft kart
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            int MablaghEnteghal;
            atmdatabase.Close();
            atmdatabase.Open();
            MablaghEnteghal = Convert.ToInt32(lblmoneytransfor.Text);
            int Sum = Depositm - MablaghEnteghal;
            string UpdateMablagh = "Update Account Set Card_Inventory='" + Sum + "' Where Id_Card='" + IdCard + "' ";
            SqlCommand com = new SqlCommand(UpdateMablagh, atmdatabase);

            com.ExecuteNonQuery();

            //enteghal mablagh Az hesab...
            //__________________________________________________________________________________________________________
            cmd.Parameters.Clear();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "insert into movement (IdCardDestination,BankName,AccountHolder,Moneytransfrom,Date,Time)Values(@a,@b,@c,@d,@e,@f)";
            cmd.Parameters.AddWithValue("@a", lbldestinationcard.Text);
            cmd.Parameters.AddWithValue("@b", lblAccountdestination.Text);
            cmd.Parameters.AddWithValue("@c", lblholdercard.Text);
            cmd.Parameters.AddWithValue("@d", lblmoneytransfor.Text);
            cmd.Parameters.AddWithValue("@e", Date);
            cmd.Parameters.AddWithValue("@f", lbltime2.Text);

            cmd.ExecuteNonQuery();
            atmdatabase.Close();
            MessageBox.Show("انتقال وجه انجام شد .");
            //___________________________________________________________________________________________________
            int DepositN;
            atmdatabase.Close();
            SqlDataReader DR;
            cmd = new SqlCommand();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "Select Card_Inventory from Account where PassWord=@N";
            cmd.Parameters.AddWithValue("@N", txtpassword.Text);
            atmdatabase.Open();
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                DepositN = Convert.ToInt32(DR["Card_Inventory"]);
            }
            else
            {

                return;
            }
            atmdatabase.Close();

            stcmoneytransfer.SelectedTab = Bankingoperations;
            //Inghesmat jahat enteghal mablagh mibashad

            //___________________________________________________________________________________________________
            StiReport Report = new StiReport();
            Report.Load("Report/rptmovement.mrt");
            Report.Compile();
            Report["BankName"] = BankName;
            Report["BankName2"] = lblAccountdestination.Text;
            Report["IDCard"] = lblmycard.Text;
            Report["IdCardDestination"] = lbldestinationcard.Text;
            Report["NamePerson"] = NamePerson;
            Report["Move"] = Convert.ToInt32(lblmoneytransfor.Text);
            Report["Deposit"] = Convert.ToInt32(DepositN);
            Report["Time"] = lbltime.Text;
            Report["Date"] = Date;
            Report.ShowWithRibbonGUI();


            //Inghesmat jahat chap enteghal mablagh mibashad
            //______________________________________________________________________
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {
            new frmmovement().ShowDialog();
            // Namayesh gozaresh enteghal mablagh
        }

        private void Mojoodi_Click(object sender, EventArgs e)
        {

        }
        //__________________________________________________________________
        private void ViewInventory_Click(object sender, EventArgs e)
        {

            atmdatabase.Close();
            SqlDataReader DR;
            cmd = new SqlCommand();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "Select Card_Inventory from Account where PassWord=@N";
            cmd.Parameters.AddWithValue("@N", txtpassword.Text);
            atmdatabase.Open();
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                lblmojoudi.Text = DR["Card_Inventory"].ToString();
                stcmoneytransfer.SelectedTab = Mojuodi;
            }
            else
            {
                MessageBox.Show("رمز اشتباه است", "خطا");
                txtpassword.Text = "";
                txtpassword.Focus();
                return;
            }
            atmdatabase.Close();
            stcmoneytransfer.SelectedTab = Mojuodi;

            //Moshahedehye Mojoudi
        }
        //___________________________________________________
        private void buttonX6_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonX6_Click_1(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //enseraf Va daryaft kart
        }
        private void buttonX8_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptMojoudi.mrt");
            Report.Compile();
            Report["BankName"] = BankName;
            Report["IDCard"] = IdCard;
            Report["NamePerson"] = NamePerson;
            Report["Deposit"] = Convert.ToInt32(lblmojoudi.Text);
            Report["Time"] = lbltime.Text;
            Report["Date"] = Date;
            Report.ShowWithRibbonGUI();
            //namayesh gozaresh va chap etela'at
        }

        private void Password_operation_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = stipass;
            //enteghal Be mahal kart be kart kardan puol
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //ba click bar dokmeh enseraf Be safheh asli montaghel mishavim .
            //_____________________________________________________________________________________
        }

        private void btnchangepass_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtpassword.Text != txtoldpass.Text)
                {
                    MessageBox.Show("رمز اشتباه است");
                }
                else
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = atmdatabase;
                    cmd.CommandText = "Update Account Set PassWord='" + txtnewpass.Text + "' where PassWord=" + txtoldpass.Text;
                    atmdatabase.Open();
                    cmd.ExecuteNonQuery();
                    atmdatabase.Close();
                    MessageBox.Show("عملیات تغییر رمز انجام شد");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("رمز اشتباه است");
            }
        }
        private void invoice_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = stsoorathesab;
            //soorathesab
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = stsoorathesab;
            //soorathesab
        }
        private void buttonX10_Click(object sender, EventArgs e)
        {
            stcmoneytransfer.SelectedTab = Main_Menu;
        }

        private void msksrchdate2_TextChanged(object sender, EventArgs e)
        {

        }

        private void msksrchdate1_TextChanged(object sender, EventArgs e)
        {

        }

        private void msksrchdate1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void msksrchdate1_TextChanged_1(object sender, EventArgs e)
        {
            Displaymove();
            Displaybardasht();
            Displayvariz();
        }

        private void msksrchdate2_TextChanged_1(object sender, EventArgs e)
        {
            Displaymove();
            Displaybardasht();
            Displayvariz();
        }

        private void Cancel10_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //enseraf Va daryaft kart
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            stcmoneytransfer.SelectedTab = Main_Menu;
            //enseraf az kart be kart kardan va bazgasht be safhe aval
        }
        private void btncheck_Click(object sender, EventArgs e)
        {

            atmdatabase.Close();
            SqlDataReader DR;
            cmd = new SqlCommand();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "Select Card_Inventory from Account where PassWord=@N";
            cmd.Parameters.AddWithValue("@N", txtpassword.Text);
            atmdatabase.Open();
            DR = cmd.ExecuteReader();
            if (DR.Read())
            {
                DepositNew = Convert.ToInt32(DR["Card_Inventory"]);

                if (Convert.ToInt32(txtdepisitamount.Text) > DepositNew)
                {
                    MessageBox.Show("موجودی کافی نیست");
                }
            }
            //dar soorati ke mablagh enteghal kamtar az mojoodi hesab bashad mablagh montaghel mishavad dar gheyr in soorat payam kafi naboodan mojoodi namayesh dade mishavad
            //__________________________________________
            atmdatabase.Close();

            SqlDataReader DR1;
            cmd = new SqlCommand();
            cmd.Connection = atmdatabase;
            cmd.CommandText = "Select * from BankCard where IDCard=@N";
            cmd.Parameters.AddWithValue("@N", txtidcard.Text);
            atmdatabase.Open();
            DR1 = cmd.ExecuteReader();
            if (DR1.Read())
            {
                Accountdestination = DR1["NameBank"].ToString();
                AccountdestinationHolder = DR1["Name_Bank_Account_Holder"].ToString();
                idcarddestination = DR1["IDCard"].ToString();
            }
            else
            {
                MessageBox.Show("شماره کارت اشتباه است");//dar soorati ke shomare kart maghsad eshtebah bashd in payam namayesh dadeh mishavad
                return;
            }


            //]In ghesmat Baraye Kart Be Kart Kardan Neveshteh Shode ast
            //_______________________________________________________________ersal etela'at

            lblholdercard.Text = AccountdestinationHolder;
            lblAccountdestination.Text = Accountdestination;
            lbldestinationcard.Text = idcarddestination;
            lblmoneytransfor.Text = txtdepisitamount.Text;

            lblmycard.Text = IdCard;
            stcmoneytransfer.SelectedTab = stdepisitamount;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.Hour.ToString("0#");
            lbltime.Text += ":";
            lbltime.Text += DateTime.Now.Minute.ToString("0#");
            lbltime.Text += ":";
            lbltime.Text += DateTime.Now.Second.ToString("0#");
            //_________________________________________________
            lbltime2.Text = DateTime.Now.Hour.ToString("0#");
            lbltime2.Text += ":";
            lbltime2.Text += DateTime.Now.Minute.ToString("0#");
            lbltime2.Text += ":";
            lbltime2.Text += DateTime.Now.Second.ToString("0#");
            //jahat namayesh saat
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveBackUp = new SaveFileDialog();
            string filename = string.Empty;
            SaveBackUp.OverwritePrompt = true;
            SaveBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            SaveBackUp.DefaultExt = "Bak";
            SaveBackUp.FilterIndex = 1;
            SaveBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            SaveBackUp.Title = "Backup SQL File";
            if (SaveBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = SaveBackUp.FileName;
                Backup(filename);
            }
        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            OpenFileDialog OpenBackUp = new OpenFileDialog();
            OpenBackUp.Filter = @"SQL Backup Files ALL Files (*.*) |*.*| (*.Bak)|*.Bak";
            OpenBackUp.FilterIndex = 1;
            OpenBackUp.Filter = @"SQL Backup Files (*.*)|";

            OpenBackUp.FileName = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            if (OpenBackUp.ShowDialog() == DialogResult.OK)
            {
                filename = OpenBackUp.FileName;
                Restore(filename);
            }
        }

        private void lblmojoufii_Click(object sender, EventArgs e)
        {

        }

        private void Mojoodi_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonX10_Click_1(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
        private void Backup(string filename)
        {
            SqlConnection con = null;
            try
            {
                string Backup = @"Backup DataBase [ATM] To Disk='" + filename + "'";
                SqlCommand cmd = null;
                con = new SqlConnection("Data Source=.;Initial Catalog=ATM;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand(Backup, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("پشتيبان گيري انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void Restore(string filename)
        {
            SqlConnection con = null;
            try
            {
                string Restore = @"ALTER DATABASE [ATM] SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE [ATM] FROM DISK= N'" + filename + "'WITH RECOVERY, REPLACE";
                SqlCommand cmd = null;
                con = new SqlConnection("Data Source=.;Initial Catalog=ATM;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand(Restore, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("بازيابي اطلاعات انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void Back_up(string filename)
        {
            SqlConnection atmdatabase = null;
            try
            {
                string Backup = @"Backup DataBase [ATM] To Disk='" + filename + "'";
                SqlCommand cmd = null;
                atmdatabase = new SqlConnection("Data Source=.;Initial Catalog=ATM;Integrated Security=True");
                atmdatabase.Open();
                cmd = new SqlCommand(Backup, atmdatabase);
                cmd.ExecuteNonQuery();
                MessageBox.Show("پشتيبان گيري انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                atmdatabase.Close();
            }
        }


        private void RESTORE(string filename)
        {
            SqlConnection atmdatabase = null;
            try
            {
                string Restore = @"ALTER DATABASE [ATM] SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE [ATM] FROM DISK= N'" + filename + "'WITH RECOVERY, REPLACE";
                SqlCommand cmd = null;
                atmdatabase = new SqlConnection("Data Source=.;Initial Catalog=ATM;Integrated Security=True");
                atmdatabase.Open();
                cmd = new SqlCommand(Restore, atmdatabase);
                cmd.ExecuteNonQuery();
                MessageBox.Show("بازيابي اطلاعات انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
            finally
            {
                atmdatabase.Close();
            }

        }
    }
}
