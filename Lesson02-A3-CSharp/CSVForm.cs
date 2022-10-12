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

namespace Lesson02_A3_CSharp
{
    public partial class CSVForm : Form
    {
        private DataGridView dataGridView1;
        private List<string[]> rows;

        public CSVForm(string csv, bool headers)
        {
            InitializeComponent();
           
            this.Text = csv.Split('\\').Last();

            rows = File.ReadAllLines(csv).Select(row => row.Split(',')).ToList();

            DataTable dt = new DataTable();

            int maxLength = rows.Select(row => row.Length).Max();

            if (headers) { 

                foreach (string col in rows[0])
                {
                    dt.Columns.Add(col);
                }

                for(int i = rows[0].Length + 1; i <= maxLength; i++)
                {
                    dt.Columns.Add(i.ToString());
                }

                foreach (string[] row in rows.Skip(1))
                {
                    dt.Rows.Add(row);
                }

              
                dataGridView1.DataSource = dt;

            }
            else {
               

                for(int i = 1; i <= maxLength; i++)
                {
                    dt.Columns.Add(i.ToString());
                }

                rows.ForEach(x => {
                    dt.Rows.Add(x);
                });
                dataGridView1.DataSource = dt;


            }

           

        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = this.BackColor;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(996, 583);
            this.dataGridView1.TabIndex = 0;
            // 
            // CSVForm
            // 
            this.ClientSize = new System.Drawing.Size(996, 583);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CSVForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        
    }
}