using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using Galcon.Events;
using Galcon.Filling;
using Galcon.Providers;

namespace Galcon.Core
{
    public class Planet : MonoBehaviour, IFillable<Text>, IFillable<Player>, IFillable<GameObjectsProvider>
    {
        [Range(1, 999)]
        [SerializeField] private int _shipsCapacity = 100;
        [Range(1, 999)]
        [SerializeField] private int _shipsNumber = 0;
        [SerializeField] private AnimationCurve _shipsProductionSpeedCurve;

        [SerializeField] private Text _shipsNumberText;
        [SerializeField] private GameObject _shipPrefab;
        [SerializeField] private GameObjectsProvider _shipsProvider;

        [SerializeField] private UnityPlayerEvent _ownerChanged;

        private Player _owner = default(Player);


        public Player Owner => _owner;


        public void Initialize()
        {
            RestartCreateShipsCoroutine();
        }


        public void Fill(Text data)
        {
            _shipsNumberText = data;
        }


        public void Fill(Player player)
        {
            _owner = player;
            _shipPrefab = player.ShipPrefab;
            _ownerChanged?.Invoke(player);
        }


        public void Fill(GameObjectsProvider shipsProvider)
        {
            _shipsProvider = shipsProvider;
        }


        public void OnShipArrived(Ship ship)
        {
            if (ship.Target != this) return;

            if (ship.Owner == _owner)
            {
                _shipsNumber++;
            }
            else
            {
                if (_shipsNumber == 0)
                {
                    _shipsNumber++;
                    _owner = ship.Owner;
                }
                else
                {
                    _shipsNumber--;
                }
            }

            RestartCreateShipsCoroutine();
        }


        public void SendShips(GameObject target, float shipsToSendPercent)
        {
            int shipsToSendNumber = Mathf.CeilToInt(_shipsNumber * (shipsToSendPercent / 100f));
            for (int i = 0; i < shipsToSendNumber; i++)
            {
                SendShip(target);
            }

            RestartCreateShipsCoroutine();
        }


        private void SendShip(GameObject target)
        {
            _shipsNumber--;

            Ship ship = _shipsProvider.ProvideAndReturn(_shipPrefab).GetComponent<Ship>();
            ship.transform.position = transform.position;

            ship.Initialize(_owner, target);
        }


        private void RestartCreateShipsCoroutine()
        {
            StopCoroutine(nameof(CreateShipsCoroutine));
            StartCoroutine(nameof(CreateShipsCoroutine));
        }


        private IEnumerator CreateShipsCoroutine()
        {
            bool isStarted = false;

            while (_shipsNumber < _shipsCapacity)
            {
                if (isStarted)
                {
                    _shipsNumber++;
                    ShipsNumberChanged();
                }
                else
                {
                    isStarted = true;
                }

                float filledShipsCapacityPercent = (float)_shipsNumber / _shipsCapacity;
                float delayDuration = 1f / _shipsProductionSpeedCurve.Evaluate(filledShipsCapacityPercent);
                yield return new WaitForSeconds(delayDuration);
            }
        }


        private void ShipsNumberChanged()
        {
            _shipsNumberText.text = _shipsNumber.ToString();
        }
    }
}
