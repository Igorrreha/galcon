using Galcon.Core;
using Galcon.Events;

namespace Galcon.PropertyGetters
{
    public class OwnerFromPlanetGetter : ConveyorPropertyFromItemGetter<Planet, Player, UnityPlayerEvent>
    {
        protected override Player Get(Planet item) => item.Owner;
    }
}
