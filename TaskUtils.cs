namespace Laboratorinis1
{
    public class TaskUtils
    {
        /// <summary>
        /// Method for searching and cheking all matrix windows
        /// </summary>
        /// <param name="map">map matrix where all searching will be doing</param>
        /// <param name="man_cord">Path starting coordinates</param>
        /// <param name="shop_cord">Ending coordinates of what is searching(Path ending coordinates)</param>
        /// <param name="size">Map matrix size</param>
        public static void Path(char[,] map, Coordinates man_cord, Coordinates shop_cord, int size)
        {
            int i, j;
            bool flag = false;
            int new_moves = 1;
            int old_moves;
            int[] i1 = new int[size * size];
            int[] j1 = new int[size * size];
            int[] i2 = new int[size * size];
            int[] j2 = new int[size * size];
            shop_cord.I = shop_cord.J = -1;
            i2[new_moves] = man_cord.I; j2[new_moves] = man_cord.J;
            while (!flag && new_moves != 0)
            {
                for (int y = 1; y <= new_moves; y++)
                { // previous front becomes the initial one
                    i1[y] = i2[y]; j1[y] = j2[y];
                }
                old_moves = new_moves; // counter of the previous front
                new_moves = 0; // new front counter
                while (old_moves > 0 && !flag)
                {
                    i = i1[old_moves];
                    j = j1[old_moves];
                    old_moves = old_moves - 1;
                    if (!flag) Checker(i - 1, j, ref flag, 'v', ref new_moves, ref i2, ref j2, ref shop_cord, map);
                    if (!flag) Checker(i, j + 1, ref flag, 'd', ref new_moves, ref i2, ref j2, ref shop_cord, map);
                    if (!flag) Checker(i + 1, j, ref flag, 'a', ref new_moves, ref i2, ref j2, ref shop_cord, map);
                    if (!flag) Checker(i, j - 1, ref flag, 'k', ref new_moves, ref i2, ref j2, ref shop_cord, map);
                }
            }
        }
        /// <summary>
        /// Checks given coordinate
        /// </summary>
        /// <param name="i">given coordinate of row</param>
        /// <param name="j">given coordinate of cell</param>
        /// <param name="flag">The logical value of the check or the end found</param>
        /// <param name="move">Step direction</param>
        /// <param name="new_moves">Quantity for checking required directions</param>
        /// <param name="i2">The array is designed to store the row coordinates that will need to be checked again</param>
        /// <param name="j2">The array is designed to store the cell coordinates that will need to be checked again</param>
        /// <param name="shop_cord">Path ending coordinates</param>
        /// <param name="map">map matrix where all map is stored</param>
        private static void Checker(int i, int j, ref bool flag, char move, ref int new_moves, ref int[] i2, ref int[] j2, ref Coordinates shop_cord, char[,] map)
        {
            if (map[i, j] == 'G')
            {
                flag = true;
                shop_cord.I = i; shop_cord.J = j;
            }
            else if (map[i, j] == '0')
            {
                new_moves++;
                i2[new_moves] = i; j2[new_moves] = j;
                map[i, j] = move;
            }
            else if (map[i, j] == '.')
            {
                if (move == 'v')
                    if (map[i - 1, j] == '0')
                    {
                        map[i, j] = move; map[i - 1, j] = move;
                        new_moves++;
                        i2[new_moves] = i - 1; j2[new_moves] = j;
                    }
                    else if (map[i - 1, j] == 'G')
                    {
                        flag = true;
                        shop_cord.I = i - 1; shop_cord.J = j;
                        map[i, j] = move;
                    }
                if (move == 'd')
                    if (map[i, j + 1] == '0')
                    {
                        map[i, j] = move; map[i, j + 1] = move;
                        new_moves++;
                        i2[new_moves] = i; j2[new_moves] = j + 1;
                    }
                    else if (map[i, j + 1] == 'G')
                    {
                        flag = true;
                        shop_cord.I = i; shop_cord.J = j + 1;
                        map[i, j] = move;
                    }
                if (move == 'a')
                    if (map[i + 1, j] == '0')
                    {
                        map[i, j] = move; map[i + 1, j] = move;
                        new_moves++;
                        i2[new_moves] = i + 1; j2[new_moves] = j;
                    }
                    else if (map[i + 1, j] == 'G')
                    {
                        flag = true;
                        shop_cord.I = i + 1; shop_cord.J = j;
                        map[i, j] = move;
                    }
                if (move == 'k')
                    if (map[i, j - 1] == '0')
                    {
                        map[i, j] = move; map[i, j - 1] = move;
                        new_moves++;
                        i2[new_moves] = i; j2[new_moves] = j - 1;
                    }
                    else if (map[i, j - 1] == 'G')
                    {
                        flag = true;
                        shop_cord.I = i; shop_cord.J = j - 1;
                        map[i, j] = move;
                    }
            }
        }
        /// <summary>
        /// Fills the path where need to go whit K chars
        /// </summary>
        /// <param name="map">A map matrix in which the path was searched and directions were listed</param>
        /// <param name="map_copy">Map matrix where all path will be added</param>
        /// <param name="shop_cord">Path ending coordinates</param>
        /// <param name="men_cord">Path starting coordinates</param>
        public static void AddPath(char[,] map, char[,] map_copy, Coordinates shop_cord, Coordinates men_cord)
        {
            int i, j;
            char ch;
            i = shop_cord.I; j = shop_cord.J;
            map_copy[i, j] = 'K'; // shop of flowers
            if (map[i - 1, j] == 'a')
                i--;
            else
            if (map[i + 1, j] == 'v')
                i++;
            else
            if (map[i, j + 1] == 'k')
                j++;
            else
                j--;
            ch = map[i, j];
            map_copy[i, j] = 'K';
            while ((i != men_cord.I) || (j != men_cord.J))
            {
                if (ch == 'v')
                    i++;
                else
                if (ch == 'a')
                    i--;
                else
                if (ch == 'k')
                    j++;
                else
                    j--;
                map_copy[i, j] = 'K';
                ch = map[i, j];
            }
        }
        /// <summary>
        /// Method for calculating past quarters
        /// </summary>
        /// <param name="map">Map matrix where all path is added</param>
        /// <param name="starting_map">Map matrix where in which no changes have been made</param>
        /// <param name="i">Coordinate of row, which will be used for tracking a path</param>
        /// <param name="j">Coordinate of cell, which will be used for tracking a path</param>
        /// <param name="i1">Clder coordinate of row, which will was used for tracking a path</param>
        /// <param name="j1">Older coordinate of cell, which will was used for tracking a path</param>
        /// <param name="quarters">number of quarters passed</param>
        /// <param name="g_shop">Path ending coordinates</param>
        /// <returns>Boolean if the path is cheked or no</returns>
        public static bool Quarters(char[,] map, char[,] starting_map, int i, int j, int i1, int j1, ref int quarters, Coordinates g_shop)
        {
            if ((i != g_shop.I) | (j != g_shop.J))
            {
                if (starting_map[i, j] == '.')
                {
                    quarters++;
                }
                if ((map[i + 1, j] == 'K') && (i1 != i + 1))
                {
                    Quarters(map, starting_map, i + 1, j, i, j, ref quarters, g_shop);
                }
                if ((map[i - 1, j] == 'K') && (i1 != i - 1))
                {
                    Quarters(map, starting_map, i - 1, j, i, j, ref quarters, g_shop);
                }
                if ((map[i, j + 1] == 'K') && (j1 != j + 1))
                {
                    Quarters(map, starting_map, i, j + 1, i, j, ref quarters, g_shop);
                }
                if ((map[i, j - 1] == 'K') && (j1 != j - 1))
                {
                    Quarters(map, starting_map, i, j - 1, i, j, ref quarters, g_shop);
                }
                return false;
            }
            return true;
        }
    }
}