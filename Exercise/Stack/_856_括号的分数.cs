namespace Function.Stack
{
    public class _856_括号的分数
    {
        public int ScoreOfParentheses(string s) //"()(())()"
        {
            int score = 0;
            int deepth = 1;
            s = s.Replace("()", "1");
            foreach (char c in s)
            {
                if (c == '(')
                {
                    deepth = deepth << 1;
                }
                else if (c == ')')
                {
                    deepth = deepth >> 1;
                }

                if (c == '1')
                {
                    score += deepth;
                }
            }
            return score;
        }
    }
}