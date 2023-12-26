using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


namespace LMS.Utility
{
    public class ParticleUtil
    {
        public static Color ConvertHexToColor(string colorName)
        {
            Color _returnColor;
            ColorUtility.TryParseHtmlString(colorName, out _returnColor);
            return _returnColor;
        }

        public static void SetParticleColor(ParticleSystem particleSystem)
        {
            
        }

        public static void SetParticleGradientColor(ParticleSystem particleSystem, Color32 c1, Color32 c2)
        {
            ParticleSystem.MainModule _mainM = particleSystem.main;
            ParticleSystem.MinMaxGradient _startColor = _mainM.startColor;
            _startColor = new ParticleSystem.MinMaxGradient(c2, c1);

            _mainM.startColor = _startColor;
        }

        public static void SetParticleRandomTwoColors(ParticleSystem particleSystem, Color32 c1, Color32 c2)
        {

        }

        public static void SetParticleLoop(ParticleSystem particleSystem, bool active)
        {
            var _mainM = particleSystem.main;
            _mainM.loop = active;
        }
    }
}