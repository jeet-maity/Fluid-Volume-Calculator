namespace Util
{
    /// <summary>Represents a measurement of an area</summary>
    public interface IUnitOfArea
    {
        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        decimal Value { get; set; }
        /// <summary>Gets or sets the unit.</summary>
        /// <value>The unit.</value>
        AreaUnit Unit { get; set; }
    }
}