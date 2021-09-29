using UnityEngine;

using Galcon.Core;
using Galcon.Events;

namespace Galcon.PropertyGetters
{
    public class ColorFromPlayerGetter : ConveyorPropertyFromItemGetter<Player, Color, UnityColorEvent>
    {
        protected override Color Get(Player item) => item.Color;
    }
}
