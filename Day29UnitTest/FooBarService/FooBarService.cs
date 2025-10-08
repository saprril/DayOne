using System.Collections;
using System.Data;
using System.Text;
namespace FooBarService;


public class FooBar
{
    public Dictionary<int, string> RuleSetDict { get; set; }

    public FooBar()
    {
        RuleSetDict = new Dictionary<int, string>();
    }
    public FooBar(int integerX, string stringX)
    {
        RuleSetDict = new Dictionary<int, string>();
        RuleSetDict[integerX] = stringX;
    }

    public string FooBarProcessor(int val)
    {
        StringBuilder decisionSb = new StringBuilder();
        List<string> valuesByKeyOrder = RuleSetDict.OrderBy(kv => kv.Key)
                                                    .Select(kv => kv.Value)
                                                    .ToList();
        if (!IsDivisibleByAnyMember(val))
        {
            decisionSb.Append(val);
        }
        else
        {
            for (int i = 0; i < valuesByKeyOrder.Count; i++)
            {
                if (ModuloProcessor(val)[i])
                {
                    decisionSb.Append(valuesByKeyOrder[i]);
                }
            }
        }

        return decisionSb.ToString();
    }

    public bool IsDivisibleByAnyMember(int value)
    {
        return ModuloProcessor(value).Cast<bool>().Any(b => b);
    }

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
        // Console.WriteLine(string.Join("", divisibility.Cast<bool>().Select(b => b ? "1" : "0")));

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
        Console.WriteLine(string.Join(", ", stringArray));
    }
}

