namespace MiguelGameDev
{
    public class RandomPickChances<T>
    {
        public T Pick { get; }
        public float Chances { get; set; }

        public RandomPickChances(T pick, float chances)
        {
            Pick = pick;
            Chances = chances;
        }
    }
}