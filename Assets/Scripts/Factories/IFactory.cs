namespace Galcon.Factories
{
    public interface IFactory<TOut, TIn>
    {
        public TOut Create(TIn data);
    }
}
