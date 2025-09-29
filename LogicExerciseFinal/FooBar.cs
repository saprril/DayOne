using System.Collections;
using System.Data;
using System.Text;

namespace LogicExerciseFinal
{
    class FooBar
    {
        public Dictionary<int, string> RuleSetDict { get; set; }
        public FooBar(int integerX, string stringX)
        {
            RuleSetDict = new Dictionary<int, string>();
            RuleSetDict[integerX] = stringX;
        }

        Func<int, string> FooBarProcessor = (val) =>
        {
            StringBuilder decisionSb = new StringBuilder();
            return decisionSb.ToString();
        };

        public BitArray ModuloProcessor(int value)
        {
            BitArray divisibility = new BitArray(RuleSetDict.Count);
            List<int> divisorList = RuleSetDict.Keys.OrderBy(k => k).ToList();

            for (int i = 0; i < divisorList.Count; i++)
            {
                if (value % divisorList[i] == 0)
                {
                    foreach (var b in divisorList)
                    {
                        if (divisorList[i] == b) continue; // skip self
                        if (divisorList[i] % b == 0)
                        {
                            divisibility[divisorList.IndexOf(b)] = false;
                        }
                    }
                    divisibility[i] = true;
                }
            }
            Console.WriteLine(string.Join("", divisibility.Cast<bool>().Select(b => b ? "1" : "0")));

            return divisibility;
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
            if (RuleSetDict.Keys.Contains(integerX))
            {
                RuleSetDict.Remove(integerX);
            }
        }


        public void PrintNumber(int number)
        {
            int[] numberArray = Enumerable.Range(1, number).ToArray();
            string[] stringArray = numberArray.Select(FooBarProcessor).ToArray();
            Console.WriteLine(string.Join(", ", numberArray));
        }
    }
}