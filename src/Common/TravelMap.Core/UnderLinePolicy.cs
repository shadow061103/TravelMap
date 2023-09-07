using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TravelMap.Core
{
    public class UnderLinePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return UnderLineString(name.ToCharArray());
        }

        private static string UnderLineString(Span<char> chars)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(char.ToLower(chars[0]));
            for (int i = 1; i < chars.Length; i++)
            {
                if (char.IsUpper(chars[i]))
                {
                    stringBuilder.Append("_");
                }

                stringBuilder.Append(char.ToLower(chars[i]));
            }

            return stringBuilder.ToString();
        }
    }
}