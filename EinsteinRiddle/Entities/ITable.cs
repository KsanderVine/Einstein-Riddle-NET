namespace EinsteinRiddle.Entities
{
    public interface ITable<TData> : IEnumerable<TData>
    {
        int ColumnsCount { get; }
        int RowsCount { get; }

        void AddRow(TData row);
    }
}