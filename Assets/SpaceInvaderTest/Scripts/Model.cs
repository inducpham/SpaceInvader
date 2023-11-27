using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaderTest
{
    public class Model : MonoBehaviour
    {
        public static Model Instance { get; private set; }

        [SerializeField]
        private ModelData modelData;
        public static ModelData Data => Instance.modelData;

        public void Awake()
        {
            //if instance exists and it is not this: disable this and exit the function
            if (Instance != null && Instance != this)
            {
                gameObject.SetActive(false);
                return;
            }

            //otherwise set instance to this and dont destroy on load
            Instance = this;
            DontDestroyOnLoad(gameObject);

            //Call function initialize
            Initialize();
        }

        public void Initialize()
        {
            //call function setupdata
            modelData.SetupData();
        }
    }
}