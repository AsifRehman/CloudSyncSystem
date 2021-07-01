using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudSyncSystem.Model;

namespace CloudSyncSystem
{
    public partial class Form1 : Form
    {
        static string party_ts = "0";
        static string party_del_ts = "0";
        static string ledger_ts = "0";
        static string ledger_del_ts = "0";
        static MongoHelper db;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize MongoDb
            string dbName=  ConfigurationManager.AppSettings["DbName"];
            db = new MongoHelper(dbName);

            lblStat.Text = "Initialized";
            lblStat.ForeColor = Color.DarkGreen;
        }

        #region Party Update Algorithm
        private async Task PartyUpdate(bool isStart = false)
        {
            //1
            party_ts = isStart ? "0" : await db.MaxTs("Party");
            //2
            SqlHelper h = new SqlHelper();
            SqlDataReader dr = await h.GetReaderBySQL("SELECT * FROM web_vw_party WHERE ts>" + party_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToPartyCollection(dr);
                lblStat.Text = "Running Party_Update Batch Operation till " + dr.GetInt32(8).ToString() + " timestamp";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Party_Update Batch Operation till " + party_ts + " timestamp";

        }
        private async static Task AddToPartyCollection(SqlDataReader sqlReader)
        {
            Party p = new Party();
            p.Id = sqlReader.GetInt32(0);
            p.PartyName = sqlReader.GetString(1);
            p.PartyTypeId = sqlReader.GetInt32(2);
            p.Debit = (sqlReader[3] as int?).GetValueOrDefault();
            p.Credit = (sqlReader[4] as int?).GetValueOrDefault();
            p.Date = sqlReader.GetDateTime(5);
            p.Mobile1 = sqlReader.IsDBNull(6) ? null : sqlReader.GetString(6);
            p.Mobile2 = sqlReader.IsDBNull(7) ? null : sqlReader.GetString(7);
            p.ts = sqlReader.GetInt32(8);
            await db.UpsertRecord<Party>("Party", p.Id, p);
            party_ts = p.ts.ToString();
        }

        #endregion

        #region Party Delete Algorithm
        private async Task PartyDelete()
        {
            //1
            party_del_ts = await db.MaxTs("Party_Del");
            //2
            SqlHelper h = new SqlHelper();
            SqlDataReader dr = await h.GetReaderBySQL("SELECT DelId, ts FROM tbl_party_del WHERE ts>" + party_del_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                AddToPartyDelCollection(dr);
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Party_Delete Batch Operation till " + party_del_ts + " timestamp";
        }

        private async static void AddToPartyDelCollection(SqlDataReader sqlReader)
        {
            Party_Del p = new Party_Del();
            p.DelId = sqlReader.GetInt32(0);
            p.ts = sqlReader.GetInt32(1);
            await db .DeleteRecord<Party>("Party", p.DelId);
            await db.InsertRecord<Party_Del>("Party_Del", p);
            party_del_ts = p.ts.ToString();
        }
        #endregion

        #region Ledger Update Algorithm
        private async Task LedgerUpdate(bool isStart = false)
        {
            ////////////////////////////////////////////////////////Ledger ALGORITHM////////////////////////////////////////////////////////////////
            //1
            ledger_ts = isStart ? "0" : await db.MaxTs("Ledger");
            //2
            SqlHelper h = new SqlHelper();
            SqlDataReader dr = await h.GetReaderBySQL("SELECT * FROM web_vw_ledger WHERE ts>" + ledger_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToLedgerCollection(dr);
                lblStat.Text = "Running Ledger_Update Batch Operation till " + dr.GetInt32(8).ToString() + " timestamp";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Ledger_Update Batch Operation till " + ledger_ts + " timestamp";
        }

        private async static Task AddToLedgerCollection(SqlDataReader sqlReader)
        {
            Ledger g = new Ledger();
            g.Id = sqlReader.GetInt32(0);
            g.PartyID = sqlReader.GetInt32(1);
            if (sqlReader.IsDBNull(2))
            {
                g.VocNo = null;
            }
            else
            {
                g.VocNo = sqlReader.GetInt32(2);
            }

            g.Date = sqlReader.GetDateTime(3).ToUniversalTime();
            g.TType = sqlReader.GetString(4);
            g.Description = sqlReader.IsDBNull(5) ? null : sqlReader.GetString(5);
            if (sqlReader.IsDBNull(6))
            {
                g.Debit = null;
            }
            else
            {
                g.Debit = sqlReader.GetInt64(6);
            }
            if (sqlReader.IsDBNull(7))
            {
                g.Credit = null;
            }
            else
            {
                g.Credit = sqlReader.GetInt64(7);
            }
            g.ts = sqlReader.GetInt32(8);
            await db .UpsertRecord<Ledger>("Ledger", g.Id, g);
            ledger_ts = g.ts.ToString();
        }

        #endregion

        #region Ledger Delete Algorithm
        private async Task LedgerDelete()
        {
            //1
            ledger_del_ts = await db.MaxTs("Ledger_Del");
            //2
            SqlHelper h = new SqlHelper();
            SqlDataReader dr = await h.GetReaderBySQL("SELECT DelId,ts FROM tbl_ledger_del WHERE ts>" + ledger_del_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                AddToLedgerDelCollection(dr);
            }
            dr.Close();
            lblStat.Text = "Running Ledger_Delete Batch Operation till " + ledger_del_ts + " timestamp";
        }

        private async static void AddToLedgerDelCollection(SqlDataReader sqlReader)
        {
            Ledger_Del p = new Ledger_Del();
            p.DelId = sqlReader.GetInt32(0);
            p.ts = sqlReader.GetInt32(1);
            await db.DeleteRecord<Ledger>("Ledger", p.DelId);
            await db.InsertRecord<Ledger_Del>("Ledger_Del", p);
            ledger_del_ts = p.ts.ToString();
        }
        #endregion

        private async void btnUpdateParty_Click(object sender, EventArgs e)
        {
            await PartyUpdate();
        }
        private async void btnManualSync_Click(object sender, EventArgs e)
        {
            await UpdateAll();
        }
        async Task UpdateAll()
        {
            try
            {
                lblStat.Text = "Running Party_Update Batch Operation";
                lblStat.ForeColor = Color.LightGoldenrodYellow;
                await PartyUpdate();
                lblStat.Text = "Running Party_Delete Batch Operation";
                await PartyDelete();
                lblStat.Text = "Running Ledger_Update Batch Operation";
                await LedgerUpdate();
                lblStat.Text = "Running Ledger_Delete Batch Operation";
                await LedgerDelete();
                lblStat.Text = "All Batch Operations Completed.";
                lblStat.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {

                lblStat.Text = ex.ToString();
                lblStat.ForeColor = Color.Red;
            }

        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            lblStat.Text = "Starting to sync with cloud";
            lblStat.ForeColor = Color.DarkGreen;
            await Task.Delay(10000);
            await UpdateAll();

        }
        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnStopTimer.Enabled = true;
            btnStartTimer.Enabled = false;
        }
        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnStopTimer.Enabled = false;
            btnStartTimer.Enabled = true;

        }
        private async void button4_Click(object sender, EventArgs e)
        {
            await LedgerUpdate();
        }
        private async void button5_Click(object sender, EventArgs e)
        {
            await LedgerDelete();
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            await PartyDelete();
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void btnUpdateReceipt_Click(object sender, EventArgs e)
        {
            //await ReceiptUpdate();
        }
        private void btnDelReceipt_Click(object sender, EventArgs e)
        {
            //await ReceiptDelete();
        }
        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            //await PaymentUpdate();
        }
        private void btnDelPayment_Click(object sender, EventArgs e)
        {
            //await PaymentDelete();
        }

        private async void btnUpdatePartyFromStart_Click(object sender, EventArgs e)
        {
            await PartyUpdate(true);
        }
    }
}
