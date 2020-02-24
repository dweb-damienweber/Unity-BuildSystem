using UnityEngine;

namespace BuildSystem
{
    public class BuilderHUD : MonoBehaviour
    {
        #region System methods

        private void Awake()
        {
            _builder = FindObjectOfType<Builder>();
        }

        #endregion


        #region Methods

        public void RequestBuilder(Building building)
        {
            if (_builder != null)
                _builder.BuildRequest(building);
        }

        #endregion


        #region Private fields

        private Builder _builder = null;

        #endregion
    }
}
