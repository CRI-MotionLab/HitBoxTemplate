using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hitbox.PingPong2X
{
    public class PingPongManager : MonoBehaviour
    {
        [SerializeField]
        private int _nTargets = 3;
        private GameObject[,] _targets;

        // Start is called before the first frame update
        void Start()
        {
            _targets = new GameObject[2 , _nTargets];
        }

        private void GetImpact(Vector2 position2D_)
        {
            // Display a mark where impacts are detected
            //Vector3 pos3DSprite_ = new Vector3(position2D_.x, position2D_.y, this.gameObject.transform.position.z + 100f); // set sprite in front of Hitbox camera
            //Instantiate(_impactPrefabs, pos3DSprite_, Quaternion.identity, this.gameObject.transform);

            //this.gameObject.GetComponent<GameManager>().GetInteractPoint(position2D_); 
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}