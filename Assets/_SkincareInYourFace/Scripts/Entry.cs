using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Campero.SkincareInYourFace
{
    public class Entry : MonoBehaviour
    {
        [SerializeField, FMODUnity.BankRef] string[] _banks;
        public void Start()
        {
            StartCoroutine(LoadGameAsync());
        }

        IEnumerator LoadGameAsync()
        {
            // Start an asynchronous operation to load the scene
            var async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

            // Don't let the scene start until all Studio Banks have finished loading
            async.allowSceneActivation = false;

            foreach (var bank in _banks)
            {
                FMODUnity.RuntimeManager.LoadBank(bank, true);
            }

            // Keep yielding the co-routine until all the bank loading is done
            // (for platforms with asynchronous bank loading)
            while (!FMODUnity.RuntimeManager.HaveAllBanksLoaded)
            {
                yield return null;
            }

            // Keep yielding the co-routine until all the sample data loading is done
            while (FMODUnity.RuntimeManager.AnySampleDataLoading())
            {
                yield return null;
            }

            // Allow the scene to be activated. This means that any OnActivated() or Start()
            // methods will be guaranteed that all FMOD Studio loading will be completed and
            // there will be no delay in starting events
            async.allowSceneActivation = true;

            // Keep yielding the co-routine until scene loading and activation is done.
            while (!async.isDone)
            {
                yield return null;
            }
        }
    }
}