using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Laboratorinis1
{
    public partial class Forma1 : System.Web.UI.Page
    {
        /// <summary>
        /// Print data to page table
        /// </summary>
        /// <param name="map">Map matrix for printing</param>
        /// <param name="size">map matrix size</param>
        public void PrintDataToTable(char[,] map, int size)
        {

            for (int i = 1; i < size + 1; i++)
            {
                TableRow row = new TableRow();
                for (int j = 1; j < size+1; j++)
                {
                    TableCell cell = new TableCell();
                    if (map[i, j] == 'K')
                    {
                        cell.Attributes.Add("style", "background-color:lime");
                    }
                    cell.Text =  map[i, j].ToString();
                    row.Cells.Add(cell);
                }
                Table1.Rows.Add(row);
            }
        }
        /// <summary>
        /// Add more information to labels
        /// </summary>
        /// <param name="shop_cord">Shop coordinates</param>
        /// <param name="quarters">Number of past quarters</param>
        public void AddLabel(Coordinates shop_cord, int quarters)
        {
            if (shop_cord.I != -1)
            {
                Label1.Text = string.Format("Kvartalų skaičius iki gėlių parduotuvės: {0}", quarters);
                if (quarters >= 5)
                    Label2.Text = string.Format("Deja, kelias per ilgas iki gėlių parduotuvės.");
                else
                    Label2.Text = string.Format("Rastų gėlių parduotuvės vieta " + shop_cord.ToString());

            }
            else
                Label1.Text = string.Format("Kelio iki gėlių parduotuvės nėra");
        }
    }
}