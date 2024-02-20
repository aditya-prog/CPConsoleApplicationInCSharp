namespace StackAndQueue
{
    public class StockSpanner
    {

        private Stack<Tuple<int, int>> st; // stores a pair where first eleemnt is price and second is span
        public StockSpanner()
        {
            st = new Stack<Tuple<int, int>>();
        }

        public int GetSpan(int todayPrice)
        {
            int span = 1;

            while(st.Count != 0 && st.Peek().Item1 <= todayPrice){
                span += st.Peek().Item2;
                st.Pop();
            }

            // Push into stackl for next operation
            st.Push(Tuple.Create(todayPrice, span));

            return span;
        }
    }
}