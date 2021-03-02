
using static Functional.Fun;

namespace Functional
{
    public class Int
    {
        public static Option<int> Parse(string s)
        {
            return int.TryParse(s, out var r)
                ? Some(r) : None;
        }
    }
}