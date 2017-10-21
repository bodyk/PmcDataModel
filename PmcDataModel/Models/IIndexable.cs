namespace PmcDataModel.Models
{
    interface IIndexable<out T>
    {
        T this[int index] { get; }
    }
}
