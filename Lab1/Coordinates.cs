namespace Laboratorinis1
{
    public class Coordinates
    {
        public int I { get; set; }
        public int J { get; set; }
        /// <summary>
        /// Saves coordinates of object
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Collum</param>
        public Coordinates(int i, int j)
        {
            this.I = i;
            this.J = j;
        }
        /// <summary>
        /// Gives ovverided string line
        /// </summary>
        /// <returns>Cordinates of saved object added to one line</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.I, this.J);
        }
    }
}