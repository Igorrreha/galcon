namespace Galcon.Filters
{
    public abstract class EqualityFilter<TValueA, TValueB> : ComparisonFilter<TValueA, TValueB>
    {
        public override bool IsPermitted()
        {
            return ValueA?.Equals(ValueB) ?? ValueB?.Equals(ValueA) ?? true;
        }
    }
}
