using UnityEngine;

namespace Galcon.Filters
{
    public abstract class ComparisonFilter<TValueA, TValueB> : Filter
    {
        [SerializeField] private TValueA _valueA;
        [SerializeField] private TValueB _valueB;


        public TValueA ValueA => _valueA;


        public TValueB ValueB => _valueB;


        public void SetValueA(TValueA value) => _valueA = value;


        public void SetValueB(TValueB value) => _valueB = value;
    }
}
