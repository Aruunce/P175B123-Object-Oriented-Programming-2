using System;
using System.IO;

namespace Laboratorinis1
{
    public class InOutUtils
    {
        /// <summary>
        /// Reads given data
        /// </summary>
        /// <param name="fv">Data file which will be readed</param>
        /// <param name="copy">2nd copy of given map for footpath</param>
        /// <param name="starting_map">3nd copy of clean stating map</param>
        /// <param name="man_cord">Starting coordinates</param>
        /// <param name="size">map matrix size</param>
        /// <returns>Fist map copy for searching a path</returns>
        public static char[,] Read(string fv, out char[,] copy, out char[,] starting_map, out Coordinates man_cord, out int size)
        {
            char[,] map = new char[50, 50];
            starting_map = new char[50, 50];
            copy = new char[50, 50];
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                    map[i, j] = '1';
            string[] lines = File.ReadAllLines(fv);
            string line0 = lines[0];
            string[] parts = line0.Split(' ');
            size = Convert.ToInt32(parts[0]);
            int vx = Convert.ToInt32(parts[1]);
            int vy = Convert.ToInt32(parts[2]);
            man_cord = new Coordinates(vx, vy);
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                for (int j = 1; j <= size; j++)
                    map[i, j] = line[j - 1];
            }

            for (int i = 0; i < size+2; i++)
                for (int j = 0; j < size+2; j++)
                {
                    copy[i, j] = map[i, j];
                    starting_map[i, j] = map[i, j];
                }
            
            for (int i = 2; i <= size; i += 4)
                for (int j = 4; j <= size; j += 4)
                    map[i, j] = '1';
            for (int i = 4; i <= size; i += 4)
                for (int j = 2; j <= size; j += 4)
                    map[i, j] = '1';
            copy[vx, vy] = map[vx, vy] = 'Ž';
            return map;
        }
        /// <summary>
        /// Prints map to txt file
        /// </summary>
        /// <param name="fn">Result file name</param>
        /// <param name="Header">Header</param>
        /// <param name="map">which map is printing</param>
        /// <param name="size">map matrix size</param>
        /// <param name="man_cord">Starting coordinates</param>
        /// <param name="shop_cord">Ending coordinates</param>
        /// <param name="quarters">Number of past quarters</param>
        public static void Print(string fn, string Header, char[,] map, int size, Coordinates man_cord, Coordinates shop_cord, int quarters)
        {
            string dash = new string('-', size + 10);
            using (var fout = File.AppendText(fn))
            {
                fout.WriteLine(Header);
                fout.WriteLine(dash);
                fout.WriteLine("Vyro koordinatės " + man_cord.ToString());
                fout.WriteLine(dash);
                for (int i = 1; i < size + 1; i++)
                {
                    for (int y = 1; y < size + 1; y++)
                        fout.Write("{0}", map[i, y]);
                    fout.WriteLine();
                }
                fout.WriteLine(dash);
                if (shop_cord.I != -1)
                {
                    fout.WriteLine("Kvartalų skaičius iki gėlių parduotuvės : {0}", quarters);
                    if (quarters > 5)
                        fout.WriteLine("Deja, kelias per ilgas iki gėlių parduotuvės");
                    else
                        fout.WriteLine("Rastų gėlių parduotuvės vieta " + shop_cord.ToString());

                }
                else
                    fout.WriteLine("Kelias iki gėlių parduotuvės nerastas");
                fout.WriteLine();
            }
        }
    }
}