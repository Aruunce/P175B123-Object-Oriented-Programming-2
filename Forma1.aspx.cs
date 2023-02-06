using System;
using System.IO;

namespace Laboratorinis1
{
    public partial class Forma1 : System.Web.UI.Page
    {
        /// <summary>
        /// Button click status tracking (If it's clicked first time or second)
        /// </summary>
        private int ButtonClick = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("App_Data/Rez.txt")))
            {
                File.Delete(Server.MapPath("App_Data/Rez.txt"));
            }
        }
        /// <summary>
        /// After activating the method, the program activates and returns the results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            char[,] map_copy;
            char[,] starting_map;
            Coordinates man_cord;
            Coordinates shop_cord = new Coordinates(-1, -1);
            int quarters = 0;
            int size;
            char[,] map = InOutUtils.Read(Server.MapPath("App_Data/Duom3.txt"), out map_copy, out starting_map, out man_cord, out size);
            InOutUtils.Print(Server.MapPath("App_Data/Rez.txt"), "Duomenys:", starting_map, size, man_cord, shop_cord, quarters);

            if (Session["ClickCount"] != null)
            {
                ButtonClick = (int)Session["ClickCount"];
            }
            switch (ButtonClick)
            {
                case 1:
                    PrintDataToTable(starting_map, size);
                    Label1.Text = string.Format("Vyro buvimo vieta (koordinatės): " + man_cord.ToString());
                    Label2.Text = "";
                    Session["ClickCount"] = 2;
                    Button1.Text = "Rodyti rezultatus";
                    break;
                case 2:
                    TaskUtils.Path(map, man_cord, shop_cord, size);
                    if (shop_cord.I != -1)
                    {
                        TaskUtils.AddPath(map, map_copy, shop_cord, man_cord);
                        TaskUtils.Quarters(map_copy, starting_map, man_cord.I, man_cord.J, man_cord.I, man_cord.J, ref quarters, shop_cord);
                        AddLabel(shop_cord, quarters);
                    }
                    InOutUtils.Print(Server.MapPath("App_Data/Rez.txt"), "Rezultatai:", map_copy, size, man_cord, shop_cord, quarters);
                    PrintDataToTable(map_copy, size);
                    Session["ClickCount"] = 1;
                    Button1.Text = "Rodyti pradinius duomenis";
                    break;
                default:
                    break;
            }
        }
    }
}