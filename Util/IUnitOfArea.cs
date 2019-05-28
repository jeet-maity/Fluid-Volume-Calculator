namespace Util
{
    public interface IUnitOfArea
    {
        decimal Value { get; set; }
        AreaUnit Unit { get; set; }
    }
}