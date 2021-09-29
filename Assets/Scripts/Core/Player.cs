using System.Collections.Generic;

using UnityEngine;

using Galcon.Events;

namespace Galcon.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.cyan;

        [Range(1, 100)]
        [SerializeField] private int _fleetSizeToSendingPercent = 50;
        [SerializeField] private GameObject _shipPrefab;

        [SerializeField] private UnityPlanetEvent _planetSelected;
        [SerializeField] private UnityPlanetEvent _planetUnselected;


        private List<Planet> _selectedPlanets = new List<Planet>();


        public Color Color => _color;


        public GameObject ShipPrefab => _shipPrefab;


        public void OnPlanetSelected(Planet planet)
        {
            if (planet.Owner == this)
            {
                TogglePlanetSelecting(planet);
            }
            else 
            {
                SendFleet(planet);
            }
        }


        private void SendFleet(Planet targetPlanet)
        {
            foreach (Planet planet in _selectedPlanets)
            {
                planet.SendShips(targetPlanet.gameObject, _fleetSizeToSendingPercent);
            }

            DeselectAllPlanets();
        }


        private void DeselectAllPlanets()
        {
            for (int i = _selectedPlanets.Count - 1; i >= 0; i--)
            {
                TogglePlanetSelecting(_selectedPlanets[i]);
            }
        }


        private void TogglePlanetSelecting(Planet planet) {
            if (_selectedPlanets.Contains(planet))
            {
                _selectedPlanets.Remove(planet);
                _planetUnselected?.Invoke(planet);
            }
            else
            {
                _selectedPlanets.Add(planet);
                _planetSelected?.Invoke(planet);
            }
        }
    }
}
