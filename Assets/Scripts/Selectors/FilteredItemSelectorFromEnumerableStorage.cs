using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using Galcon.Storages;
using Galcon.Filters;

namespace Galcon.Selectors
{
    public abstract class FilteredItemSelectorFromEnumerableStorage<TStorage, TData, TDataItem, TItem, TEvent> : Selector
        where TStorage : EnumerableStorage<TData>
        where TData : IEnumerable, new()
        where TEvent : UnityEvent<TItem>
    {
        [SerializeField] private TStorage _storage;
        [SerializeField] private Filter _filter;

        [SerializeField] private TEvent _onItemGettedBeforeFiltering;
        [SerializeField] private TEvent _onItemSelected;
        [SerializeField] private UnityEvent _onSelectingFailed;


        public sealed override void Select()
        {
            foreach (TDataItem dataItem in _storage.Data)
            {
                TItem item = GetItemFromDataItem(dataItem);

                _onItemGettedBeforeFiltering?.Invoke(item);

                if (_filter.IsPermitted())
                {
                    _onItemSelected?.Invoke(item);
                    return;
                }
            }
            
            _onSelectingFailed?.Invoke();
        }


        protected abstract TItem GetItemFromDataItem(TDataItem dataItem);
    }
}

