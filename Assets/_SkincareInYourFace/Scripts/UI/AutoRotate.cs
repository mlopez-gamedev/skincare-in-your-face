using System;
using UnityEngine;

namespace Campero.SkincareInYourFace.UI
{
    public class AutoRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotateSpeed;

        private void OnEnable()
        {
            transform.rotation = Quaternion.identity;
        }

        private void Update()
        {
            transform.Rotate(_rotateSpeed * Time.deltaTime);
        }    
    }
}