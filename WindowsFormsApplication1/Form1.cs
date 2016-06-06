using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private static NetInfoRetriever netInfoRetriever = null;
        private List<int[]> listViewArray = null;
        private readonly SynchronizationContext synchronizationContext;
        private DateTime previousTime = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
            listViewArray = new List<int[]>();
        }

        private void resetArray(List<int[]> list)
        {
            foreach (var array in list)
            {
                array[1] = 0;
            }
        }

        private void markArray(String port)
        {
            foreach (var array in this.listViewArray)
            {
                if (array[0] == Int32.Parse(port))
                {
                    array[1] = 1;
                }
            }
        }

        private void removeOldConnections()
        {
            foreach(int[] row in this.listViewArray)
            {
                if (row[1] == 0)
                {
                    //get reference to item in listview
                    ListViewItem currentItem = this.listView1.FindItemWithText(row[0].ToString());
                    currentItem.Remove();
                }                        
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "TCP Monitor";
            netInfoRetriever = new NetInfoRetriever();
            netInfoRetriever.start(this);
        }

        public void updateUI(TcpConnectionInformation[] activeConnections)
        {
            //this.SuspendLayout();
            /*
            this.listView1.Clear(); //clear all items
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            */




        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
