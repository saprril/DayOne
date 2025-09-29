using System.Data;

namespace LogicExerciseFinal
{
    class FooBar
    {
        public Dictionary<int, string> RuleSetDict { get; set; }
        public FooBar(int integerX, string stringX)
        {
            Dictionary<int, string> RuleSetDict = new Dictionary<int, string>();
            RuleSetDict[integerX] = stringX;
        }

        public void AddRules(int integerX, string stringX)
        {
            if (!RuleSetDict.Keys.Contains(integerX))
            {
                RuleSetDict[integerX] = stringX;
            }
        }

        public void RemoveRules(int integerX)
        {
            if (!RuleSetDict.Keys.Contains(integerX))
            {
                RuleSetDict.Remove(integerX);
            }
        }

        public void PrintNumber(int number)
        {
            int[] numberArray = Enumerable.Range(1, number).ToArray();
            Console.WriteLine(string.Join(", ", numberArray));
        }
    }
}