namespace PmcDataModel.Models
{
    public class PointPath
    {
        public int MatrixNumber { get; set; }
        public int PositionNumber { get; set; }

        public bool Equals(PointPath other)
        {
            if (other == null)
                return false;

            return other.MatrixNumber == MatrixNumber && other.PositionNumber == PositionNumber;
        }
    }
}
