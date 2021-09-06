using CloudSyncSystem.Model;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudSyncSystem
{
    public partial class Form1 : Form
    {

        static string partytype_ts = "0";
        static string partytype_del_ts = "0";
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
            string dbName = ConfigurationManager.AppSettings["DbName"];
            db = new MongoHelper(dbName);

            lblStat.Text = "Initialized";
            lblStat.ForeColor = Color.DarkGreen;
        }

        #region Party Update Algorithm
        private async Task PartyUpdate(bool isStart = false)
        {
            //1
            if (party_ts == "0")
                party_ts = isStart ? "0" : await db.MaxTs("Party");
            //2
            SqlHelper h = new SqlHelper();
            int cur = 1;
            int tot = await h.GetExecuteScalarByStr("SELECT count(*) as cnt from web_vw_Party WHERE ts>" + party_ts);
            if (tot == 0)
            {
                lblStat.Text = "Party_Update Operation already Up to Date";
                return;
            }
            SqlDataReader dr = await h.GetReaderBySQL("SELECT * FROM web_vw_party WHERE ts>" + party_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToPartyCollection(dr, isStart);
                lblStat.Text = "Running Party_Update Batch Operation: " + cur++.ToString() + " of " + tot.ToString() + " updated.";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Party_Update Batch Operation Completed: " + tot.ToString() + " updated.";

        }
        private async static Task AddToPartyCollection(SqlDataReader sqlReader, bool isStart = false)
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
            if (isStart)
                await db.InsertRecord<Party>("Party", p);
            else
                await db.UpsertRecord<Party>("Party", p.Id, p);
            party_ts = p.ts.ToString();
        }

        #endregion

        #region Party Delete Algorithm
        private async Task PartyDelete(bool isStart = false)
        {
            //1
            if (party_del_ts == "0")
                party_del_ts = isStart ? "0" : await db.MaxTs("Party_Del");
            //2
            SqlHelper h = new SqlHelper();
            int cur = 0;
            int tot = await h.GetExecuteScalarByStr("SELECT count(*) as cnt from tbl_party_del WHERE ts>" + party_del_ts);
            if (tot == 0)
            {
                lblStat.Text = "Party_Delete Operation already Up to Date";
                return;
            }
            SqlDataReader dr = await h.GetReaderBySQL("SELECT DelId,ts FROM tbl_party_del WHERE ts>" + party_del_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToPartyDelCollection(dr);
                lblStat.Text = "Running Party_Delete Batch Operation: " + cur++.ToString() + " of " + tot.ToString() + " updated.";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Party_Delete Batch Operation Completed: " + tot.ToString() + " updated.";

        }

        private async static Task AddToPartyDelCollection(SqlDataReader sqlReader)
        {
            Party_Del p = new Party_Del();
            p.DelId = sqlReader.GetInt32(0);
            p.ts = sqlReader.GetInt32(1);
            await db.DeleteRecord<Party>("Party", p.DelId);
            await db.InsertRecord<Party_Del>("Party_Del", p);
            party_del_ts = p.ts.ToString();
        }
        #endregion

        #region PartyType Update Algorithm
        private async Task PartyTypeUpdate(bool isStart = false)
        {
            //1
            if (partytype_ts == "0")
                partytype_ts = isStart ? "0" : await db.MaxTs("PartyType");
            //2
            SqlHelper h = new SqlHelper();
            int cur = 1;
            int tot = await h.GetExecuteScalarByStr("SELECT count(*) as cnt from web_vw_PartyType WHERE ts>" + partytype_ts);
            if (tot == 0)
            {
                lblStat.Text = "PartyType_Update Operation already Up to Date";
                return;
            }
            SqlDataReader dr = await h.GetReaderBySQL("SELECT * FROM web_vw_PartyType WHERE ts>" + partytype_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToPartyTypeCollection(dr, isStart);
                lblStat.Text = "Running PartyType_Update Batch Operation: " + cur++.ToString() + " of " + tot.ToString() + " updated.";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PartyType ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running PartyType_Update Batch Operation Completed: " + tot.ToString() + " updated.";

        }
        private async static Task AddToPartyTypeCollection(SqlDataReader sqlReader, bool isStart = false)
        {
            PartyType p = new PartyType();
            p.Id = sqlReader.GetInt32(0);
            p.PartyTypeName = sqlReader.GetString(1);
            if (sqlReader.IsDBNull(2))
            {
                p.PartyGroup = null;
            }
            else
            {
                p.PartyGroup = sqlReader.GetString(2);
            }
            
            p.ts = sqlReader.GetInt32(3);
            if (isStart)
                await db.InsertRecord<PartyType>("PartyType", p);
            else
                await db.UpsertRecord<PartyType>("PartyType", p.Id, p);
            partytype_ts = p.ts.ToString();
        }

        #endregion

        #region PartyType Delete Algorithm
        private async Task PartyTypeDelete(bool isStart = false)
        {
            //1
            if (partytype_del_ts == "0")
                partytype_del_ts = isStart ? "0" : await db.MaxTs("PartyType_Del");
            //2
            SqlHelper h = new SqlHelper();
            int cur = 0;
            int tot = await h.GetExecuteScalarByStr("SELECT count(*) as cnt from tbl_PartyType_del WHERE ts>" + partytype_del_ts);
            if (tot == 0)
            {
                lblStat.Text = "PartyType_Delete Operation already Up to Date";
                return;
            }
            SqlDataReader dr = await h.GetReaderBySQL("SELECT DelId,ts FROM tbl_PartyType_del WHERE ts>" + partytype_del_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToPartyTypeDelCollection(dr);
                lblStat.Text = "Running PartyType_Delete Batch Operation: " + cur++.ToString() + " of " + tot.ToString() + " updated.";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PartyType ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running PartyType_Delete Batch Operation Completed: " + tot.ToString() + " updated.";

        }

        private async static Task AddToPartyTypeDelCollection(SqlDataReader sqlReader)
        {
            PartyType_Del p = new PartyType_Del();
            p.DelId = sqlReader.GetInt32(0);
            p.ts = sqlReader.GetInt32(1);
            await db.DeleteRecord<PartyType>("PartyType", p.DelId);
            await db.InsertRecord<PartyType_Del>("PartyType_Del", p);
            partytype_del_ts = p.ts.ToString();
        }
        #endregion


        #region Ledger Update Algorithm
        private async Task LedgerUpdate(bool isStart = false)
        {
            ////////////////////////////////////////////////////////Ledger ALGORITHM////////////////////////////////////////////////////////////////
            //1
            if (ledger_ts == "0")
                ledger_ts = isStart ? "0" : await db.MaxTs("Ledger");
            //2
            SqlHelper h = new SqlHelper();
            int cur = 0;
            int tot = await h.GetExecuteScalarByStr("SELECT count(*) as cnt from web_vw_Ledger WHERE ts>" + ledger_ts);
            if (tot == 0)
            {
                lblStat.Text = "Ledger_Update Operation already Up to Date";
                return;
            }
            SqlDataReader dr = await h.GetReaderBySQL("SELECT * FROM web_vw_ledger WHERE ts>" + ledger_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToLedgerCollection(dr, isStart);
                lblStat.Text = "Running Ledger_Update Batch Operation: " + cur++.ToString() + " of " + tot.ToString() + " updated.";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Ledger_Update Batch Operation Completed: " + tot.ToString() + " updated.";
        }

        private async static Task AddToLedgerCollection(SqlDataReader sqlReader, bool isStart = false)
        {
            Ledger g = new Ledger();
            g.Id = sqlReader.GetInt32(0);
            g.PartyId = sqlReader.GetInt32(1);
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
            if (isStart)
                await db.InsertRecord<Ledger>("Ledger", g);
            else
                await db.UpsertRecord<Ledger>("Ledger", g.Id, g);
            ledger_ts = g.ts.ToString();
        }

        #endregion

        #region Ledger Delete Algorithm
        private async Task LedgerDelete(bool isStart = false)
        {
            //1
            if (ledger_del_ts == "0")
                ledger_del_ts = isStart ? "0" : await db.MaxTs("Ledger_Del");
            //2
            SqlHelper h = new SqlHelper();
            int cur = 0;
            int tot = await h.GetExecuteScalarByStr("SELECT count(*) as cnt from tbl_ledger_del WHERE ts>" + ledger_del_ts);
            if (tot == 0)
            {
                lblStat.Text = "Ledger_Delete Operation already Up to Date";
                return;
            }
            SqlDataReader dr = await h.GetReaderBySQL("SELECT DelId,ts FROM tbl_ledger_del WHERE ts>" + ledger_del_ts + " Order By ts");
            //3
            while (dr.Read())
            {
                await AddToLedgerDelCollection(dr);
                lblStat.Text = "Running Ledger_Delete Batch Operation: " + cur++.ToString() + " of " + tot.ToString() + " updated.";
            }
            dr.Close();
            ///////////////////////////////////////////////////END PARTY ALGORITHM/////////////////////////////////////////////////////////////////
            lblStat.Text = "Running Ledger_Delete Batch Operation Completed: " + tot.ToString() + " updated.";

        }

        private async static Task AddToLedgerDelCollection(SqlDataReader sqlReader)
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
                lblStat.Text = "Running PartyType_Update Batch Operation";
                lblStat.ForeColor = Color.LightGoldenrodYellow;
                await PartyTypeUpdate();
                await Task.Delay(1000);
                lblStat.Text = "Running PartyType_Delete Batch Operation";
                await PartyTypeDelete();
                await Task.Delay(1000);

                lblStat.Text = "Running Party_Update Batch Operation";
                lblStat.ForeColor = Color.LightGoldenrodYellow;
                await PartyUpdate();
                await Task.Delay(1000);
                lblStat.Text = "Running Party_Delete Batch Operation";
                await PartyDelete();
                await Task.Delay(1000);
                lblStat.Text = "Running Ledger_Update Batch Operation";
                await LedgerUpdate();
                await Task.Delay(1000);
                lblStat.Text = "Running Ledger_Delete Batch Operation";
                await LedgerDelete();
                await Task.Delay(1000);
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

        private async void btnUpdateLedgerFromStart_Click(object sender, EventArgs e)
        {
            await LedgerUpdate(true);
        }

        private async void btnDeletePartyFromStart_Click(object sender, EventArgs e)
        {
            await PartyDelete(true);
        }

        private async void btnDeleteLedgerFromStart_Click(object sender, EventArgs e)
        {
            await LedgerDelete(true);
        }

        private async void btnPartyTypeUpdate_Click(object sender, EventArgs e)
        {
            await PartyTypeUpdate();
        }

        private async void btnPartyTypeDel_Click(object sender, EventArgs e)
        {
            await PartyTypeDelete();
        }
    }
}
