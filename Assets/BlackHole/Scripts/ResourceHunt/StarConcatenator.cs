using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace rIAEugth.vseioAW.segAIWUt
{
    public class StarConcatenator:MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public string MergeStellarFragments(List<string> stellarFragments)
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var str in stellarFragments)
            {
                resultBuilder.Append(str);
            }

            return resultBuilder.ToString();
        }
    }
}