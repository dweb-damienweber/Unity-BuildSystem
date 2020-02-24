using UnityEngine;

namespace BuildSystem
{
    public class Building : MonoBehaviour
    {
        #region Properties

        public Transform Transform
        {
            get;
            set;
        }

        public GameObject BuildingGameObject
        {
            get;
            private set;
        }

        public GameObject ModelGameObject
        {
            get => _modelGameObject;
        }

        public GameObject PlacerGameObject
        {
            get => _placerGameObject;
        }

        #endregion

    
        #region System methods

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            _collider = GetComponent<Collider>();
            BuildingGameObject = gameObject;
        }

        private void Update()
        {
            if (_isBuild)
            {
                // Building logic
                // ...
            }
        }

        #endregion


        #region Methods

        public void EnablePlacer()
        {
            _collider.enabled = false;

            _modelGameObject.SetActive(false);
            _placerGameObject.SetActive(true);
        }

        public void PlaceBuilding()
        {
            _collider.enabled = true;

            _placerGameObject.SetActive(false);
            _modelGameObject.SetActive(true);

            _isBuild = true;
        }

        #endregion


        #region Private fields

        private bool _isBuild = false;
        private Collider _collider = null;

        [SerializeField] private GameObject _modelGameObject = null;
        [SerializeField] private GameObject _placerGameObject = null;

        #endregion
    }
}