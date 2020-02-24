using UnityEngine;

namespace BuildSystem
{
    public class Builder : MonoBehaviour
    {
        #region System methods

        private void Awake()
        {
            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        private void Update()
        {
            if (_currentBuilding == null)
                return;

            MovePlacer();

            if (Input.GetKeyDown(KeyCode.Escape))
                CancelBuild();

            if (Input.GetButtonDown("Fire1") && _canBuildHere)
                Build();
        }

        #endregion


        #region Methods

        public void BuildRequest(Building building)
        {
            _currentBuilding = building;
            _currentBuilding = Instantiate(_currentBuilding);
            _currentBuilding.EnablePlacer();

            HideCursor();
        }

        private void MovePlacer()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _currentBuilding.Transform.position = hit.point;

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("CanBuildOn"))
                    _canBuildHere = true;
                else
                    _canBuildHere = false;
            }
        }

        private void Build()
        {
            _currentBuilding.PlaceBuilding();
            _currentBuilding = null;

            ShowCursor();
        }

        private void CancelBuild()
        {
            Destroy(_currentBuilding.BuildingGameObject);
            _currentBuilding = null;

            ShowCursor();
        }

        private void ShowCursor()
        {
            Cursor.visible = true;
        }

        private void HideCursor()
        {
            Cursor.visible = false;
        }

        #endregion


        #region Private fields

        private Camera _camera;

        private Ray ray;
        private RaycastHit hit;

        private bool _canBuildHere = true;

        private Building _currentBuilding = null;

        #endregion
    }
}