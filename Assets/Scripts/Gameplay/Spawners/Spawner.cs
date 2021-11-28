using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using Counters;
using Gameplay.Spaceships;

namespace Gameplay.Spawners
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField]
        private GameObject _object;

        [SerializeField]
        private Transform _parent;

        [SerializeField]
        private Vector2 _spawnPeriodRange;

        [SerializeField]
        private Vector2 _spawnDelayRange;

        [SerializeField]
        private bool _autoStart = true;
        [SerializeField]
        private bool _addScoreCounter = true;

        [SerializeField]
        private ScoreCounter _scoreCounter;


        private void Start()
        {
            if (_autoStart)
                StartSpawn();
        }


        public void StartSpawn()
        {
            StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }


        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_spawnDelayRange.x, _spawnDelayRange.y));

            while (true)
            {
                if (_addScoreCounter)
                {
                    Instantiate(_object, transform.position, transform.rotation, _parent).GetComponent<IScorable>().ScoreCounter = _scoreCounter; 
                }
                else
                {
                    Instantiate(_object, transform.position, transform.rotation, _parent);
                }
                yield return new WaitForSeconds(Random.Range(_spawnPeriodRange.x, _spawnPeriodRange.y));
            }
        }
    }
}
