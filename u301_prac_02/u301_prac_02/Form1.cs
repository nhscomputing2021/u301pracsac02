using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace u301_prac_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(filePath).ToList();

                float total = 0f; ;
                
                foreach (string line in lines)
                {
                    
                    List<string> fields = line.Split(',').ToList();
                    float profit;
                    //store sale price and purchased price from each line in the file into variables
                    string salePrice = fields[5];
                    float purchasedPrice = float.Parse(fields[3]);
                    
                    //calculate the profit
                    if (float.TryParse(salePrice, out float _saleprice))
                    {
                        profit = _saleprice - purchasedPrice;
                    }
                    else
                    {
                        profit = purchasedPrice * -1;
                    }
                    // add the profit to the total
                    total += profit;
                    //append the profit field into fields so it is ready to populate the datagridview
                    fields.Add(profit.ToString());
                    
                    dataGridView1.Rows.Add(fields.ToArray());
                    
                    
                }
                //create an empty row
                dataGridView1.Rows.Add();
                //grab the length of the rows in the datagridview
                int rowCount = dataGridView1.Rows.Count;
                //initialise value of the second last cell with text Total
                dataGridView1.Rows[rowCount-1].Cells[5].Value = "Total";
                //initialise value of the last cell with the value of the total
                dataGridView1.Rows[rowCount-1].Cells[6].Value = $"${total.ToString()}";





            }
           
            


        }
        

        
    }
}
