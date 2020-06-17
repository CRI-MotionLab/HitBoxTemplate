using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hitbox.PingPong2X
{
    public class TargetsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _targetPrefab;
        private List<GameObject> _targetsList;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void SetCrownTargets(Vector3 center_, int nTargets_, float radius_)
        {
            for (int i = 0; i < nTargets_; i++)
            {
                float angle_ = i * 2f * Mathf.PI / nTargets_ + Mathf.PI / 2f;
                float posX_ = radius_ * Mathf.Cos(angle_);
                float posY_ = radius_ * Mathf.Sin(angle_);
                float posZ_ = this.transform.position.z + 50;

                SetTarget(new Vector3(posX_, posY_, posZ_), i);
            }
        }

        private void SetTarget(Vector3 position_, int targetIndex_)
        {
            // Instantiate target
            _targetsList.Add((GameObject)Instantiate(_targetPrefab, position_, Quaternion.identity));
            _targetsList[_targetsList.Count - 1].GetComponent<TargetBehavior>().Index = targetIndex_;
        }

        public void GetImpact(Vector2 position2D_)
        {
            /// Get position and set raycast vector
            Vector3 cameraForward = this.transform.forward;
            Debug.DrawRay(position2D_, cameraForward * 10000, Color.yellow, 10.0f);

            /// Raycast target and action
            if (_targetsList.Count > 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(position2D_, cameraForward, out hit))
                {
                    if (hit.collider != null && hit.transform.tag == "target")
                    {
                        int targetIndex_ = hit.collider.GetComponent<TargetBehavior>().Index;
                        // --------------> inform game manager sur MainCamera
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
