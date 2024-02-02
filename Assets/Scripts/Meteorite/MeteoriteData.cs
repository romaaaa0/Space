using System.Collections.Generic;
using UnityEngine;

namespace Meteorite
{
    [CreateAssetMenu(fileName = "METEORITe", menuName = "DB/Meteorite", order = 1)]
    public class MeteoriteData : ScriptableObject
    {
        public List<AsteroidData> meteorite;
    }
}