using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortPathAStar
{
    public partial class Form1 : Form
    {
        static bool[,] field = new bool[8, 8];
        public int mapHeight = field.GetLength(0);
        public int mapWidht = field.GetLength(1);
        static int blocks = field.GetLength(0);
        static SearchParameters parameters = new SearchParameters(new Point(0, 0), new Point((field.GetLength(0) - 1), (field.GetLength(1)) - 1), field, blocks);
        PathFinder pathFinder = new PathFinder(parameters);
       
        public Form1()
        {
            InitializeComponent(); 
            dataGridView1.RowCount = mapHeight;
            dataGridView1.ColumnCount = mapWidht;
            foreach (DataGridViewColumn col in this.dataGridView1.Columns)
            {
                col.Width = 27;
            }
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Height = 27;
            }
 
            ShowMap(pathFinder.nodes, dataGridView1);
        }


        public static void ShowMap(Node[,] map, DataGridView dataGridView1)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y].IsWalkable == false)
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = System.Drawing.Color.Black;
                    }
                    else if (map[x, y].ToString() == "-2")
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        dataGridView1.Rows[x].Cells[y].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
            dataGridView1.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.Blue;
            dataGridView1.Rows[map.GetLength(0) - 1].Cells[map.GetLength(1) - 1].Style.BackColor = System.Drawing.Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Point> path = pathFinder.FindPath();
            if (path.Contains(new Point((field.GetLength(0)-1), (field.GetLength(1)-1))))
            {
                foreach (var item in path)
                {
                    dataGridView1.Rows[item.X].Cells[item.Y].Style.BackColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                MessageBox.Show("Path can't be found!");
            }  
        }        
    }
}
