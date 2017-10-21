namespace PmcDataModel.Models
{
    public class PositionPath
    {
        public int MatrixNumber { get; set; }
        public int PositionNumber { get; set; }

        public bool Equals(PositionPath other)
        {
            if (other == null)
                return false;

            return other.MatrixNumber == MatrixNumber && other.PositionNumber == PositionNumber;
        }
    }
}
