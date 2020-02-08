using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindPath
{
    public partial class Form1 : Form
    {
        int[,] map;
        public int mapHeight = 8;
        public int mapWidht = 8;
        bool nextMove = true;
        int counter = 0;

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
            map = new int[mapWidht, mapHeight];
            for (int i = 0; i < mapHeight - 1; i++)
            {
                for (int j = 0; j < mapWidht - 1; j++)
                {
                    map[i, j] = 0;
                }
            }          
            ShowMap(map, dataGridView1);
        }

      /*   public static void ShowMap(int[,] map, DataGridView dataGridView1)
         {
             for (int x = 0; x < map.GetLength(0); x++)
             {
                 for (int y = 0; y < map.GetLength(1); y++)
                     dataGridView1.Rows[x].Cells[y].Value = map[x, y];
             }
         }*/

        public static void ShowMap(int[,] map, DataGridView dataGridView1)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y].ToString() == "-1")
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

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                int x, y = 0;
                x = rand.Next(0, 8);
                y = rand.Next(0, 8);
                if ((x == y & y == 0) || (x == y & y == mapWidht - 1) || map[x, y] == -1)
                {
                    --i;
                    continue;
                }
                map[x, y] = -1;
                ShowMap(map, dataGridView1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            counter = MoveNext(0, 0, ref map);
            while (nextMove & map[map.GetLength(0) - 1, map.GetLength(1)-1] == 0)
            {
                nextMove = false;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == counter)
                        {
                            MoveNext(i, j, ref map);
                            nextMove = true;
                        }
                    }
                }
                ++counter;
            }
            if (map[map.GetLength(0) - 1, map.GetLength(1) - 1] == 0)
            {
                MessageBox.Show("It's impossible to find path");
                return;
            }

            nextMove = true;
            counter = Math.Max(map[(map.GetLength(0) - 1), (map.GetLength(1) - 2)], map[(map.GetLength(0) - 2), (map.GetLength(1) - 1)]);
           
            int startXpoint = map.GetLength(0) - 1;
            int startYpoint = map.GetLength(1) - 1;
            while (nextMove)
            {
                nextMove = ShowPath(ref startXpoint, ref startYpoint, ref counter, ref map);
            }

            ShowMap(map, dataGridView1);
        }

        public static int MoveNext(int x, int y, ref int[,] array)
        {
            int tempValue = 0;
            if (x - 1 >= 0)
            {
                if (array[x - 1, y] == 0)
                {
                    array[x - 1, y] = array[x, y] + 1;
                    tempValue = array[x, y] + 1;
                }
            }
            if (x + 1 < array.GetLength(0))
            {
                if (array[x + 1, y] == 0)
                {
                    array[x + 1, y] = array[x, y] + 1;
                    tempValue = array[x, y] + 1;
                }
            }
            if (y - 1 >= 0)
            {
                if (array[x, y - 1] == 0)
                {
                    array[x, y - 1] = array[x, y] + 1;
                    tempValue = array[x, y] + 1;
                }
            }
            if (y + 1 < array.GetLength(1))
            {
                if (array[x, y + 1] == 0)
                {
                    array[x, y + 1] = array[x, y] + 1;
                }
                tempValue = array[x, y] + 1;

            }
            return tempValue;
        }

        public static bool ShowPath(ref int x, ref int y, ref int counter, ref int[,] array)
        {
            if (x - 1 >= 0)
            {
                if (array[x - 1, y] == counter)
                {
                    array[x - 1, y] = -2;
                    --counter;
                    x = x - 1;
                    return true;
                }
            }
            if (y - 1 >= 0)
            {
                if (array[x, y - 1] == counter)
                {
                    array[x, y - 1] = -2;
                    --counter;
                    y = y - 1;
                    return true;
                }
            }
            if (x + 1 < array.GetLength(0))
            {
                if (array[x + 1, y] == counter)
                {
                    array[x + 1, y] = -2;
                    --counter;
                    x = x + 1;
                    return true;
                }
            }
            if (y + 1 < array.GetLength(1))
            {
                if (array[x, y + 1] == counter)
                {
                    array[x, y + 1] = -2;
                    --counter;
                    y = y + 1;
                    return true;
                }
            }
            return false;
        }

    }
}

