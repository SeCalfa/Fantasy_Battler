using CodeBase.Logic.AttackDirection;
using UnityEngine;

namespace CodeBase.Services
{
    public class RandomService
    {
        public ArrowDirection GetRandomDirection()
        {
            int rand = Random.Range(0, 2);

            if (rand == 0)
                return ArrowDirection.Left;
            else
                return ArrowDirection.Right;
        }
    }
}
