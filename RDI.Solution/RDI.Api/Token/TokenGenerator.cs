using System;
using System.Linq;

namespace RDI.Api.Token
{
    public sealed class TokenGenerator
    {
        private static readonly TokenGenerator instance = new();
        public static TokenGenerator Instance
        {
            get
            {
                return instance;
            }
        }
        public TokenGenerator() { }

        public long GenerateToken(long digits, int rotations)
        {
            var array = Array.ConvertAll(digits.ToString().TakeLast(4).ToArray(), x => int.Parse(x.ToString()));

            for (int i = 0; i < rotations; i++)
            {
                array = RightRotate(array);
            }

            return int.Parse(string.Join("", array));

        }

        private int[] RightRotate(int[] arr)
        {
            int size = arr.Length - 1;
            for (int i = 0; i < size; i++)
            {
                var temp = arr[0];
                arr[0] = arr[i + 1];
                arr[i + 1] = temp;
            }

            return arr;
        }
    }
}
