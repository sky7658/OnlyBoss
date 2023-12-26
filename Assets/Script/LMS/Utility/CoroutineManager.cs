using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LMS.Utility
{
    public class CoroutineManager : MonoSingleton<CoroutineManager>
    {
        public Coroutine ExecuteCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void QuitCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }

    public class CoroutineController
    {
        private Dictionary<string, Coroutine> coroutines;

        public CoroutineController()
        {
            coroutines = new Dictionary<string, Coroutine>();
        }

        public void ExecuteCoroutine(IEnumerator coroutine, string name)
        {
            if (coroutines.ContainsKey(name))
            {
                OffCoroutine(name);
                if (coroutines.TryGetValue(name, out var _coroutine))
                {
                    _coroutine = UtilCoroutine.ExecuteCoroutine(coroutine, ref _coroutine);
                    coroutines[name] = _coroutine;
                }
            }
            else
            {
                Debug.Log("Add " + name + "Coroutine");
                coroutines.Add(name, CoroutineManager.Instance.ExecuteCoroutine(coroutine));
            }
        }
        public void OffCoroutine(string name)
        {
            if (!coroutines.ContainsKey(name)) { Debug.Log("Coroutine is not exist"); return; }
            if (coroutines.TryGetValue(name, out var _coroutine))
            {
                _coroutine = UtilCoroutine.OffCoroutine(ref _coroutine);
                coroutines[name] = _coroutine;
            }
        }

        public void OffAllCoroutine() => UtilCoroutine.OffAllCoroutine(coroutines);
    }

    public class UtilCoroutine
    {
        class FloatComparer : IEqualityComparer<float>
        {
            bool IEqualityComparer<float>.Equals(float x, float y)
            {
                return x == y;
            }
            int IEqualityComparer<float>.GetHashCode(float obj)
            {
                return obj.GetHashCode();
            }
        }
        private static readonly Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>(new FloatComparer());
        public static WaitForSeconds WaitForSeconds(float seconds)
        {
            WaitForSeconds wfs;
            if (!_timeInterval.TryGetValue(seconds, out wfs))
                _timeInterval.Add(seconds, wfs = new WaitForSeconds(seconds));
            return wfs;
        }

        public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

        public static Coroutine ExecuteCoroutine(IEnumerator startCo, ref Coroutine endCo)
        {
            OffCoroutine(ref endCo);
            return CoroutineManager.Instance.ExecuteCoroutine(startCo);
        }
        public static Coroutine OffCoroutine(ref Coroutine coroutine)
        {
            if (coroutine != null) CoroutineManager.Instance.QuitCoroutine(coroutine);
            return null;
        }

        public static void OffAllCoroutine(List<Coroutine> coroutines) => coroutines.ForEach(coroutine => coroutine = OffCoroutine(ref coroutine));
        public static void OffAllCoroutine(Dictionary<string, Coroutine> coroutines)
        {
            List<string> _keys = new List<string>(coroutines.Keys);
            foreach (var _key in _keys)
            {
                if (coroutines.TryGetValue(_key, out var _coroutine))
                {
                    _coroutine = OffCoroutine(ref _coroutine);
                    coroutines[_key] = _coroutine;
                }
            }
        }
    }
}

