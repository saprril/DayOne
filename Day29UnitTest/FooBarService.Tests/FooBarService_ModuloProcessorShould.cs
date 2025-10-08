namespace FooBarService.Tests;
using FooBarService;
using System.Collections;
using System.Data;
using System.Text;


[TestFixture]
public class FooBarService_ModuloProcessorShould
{
    private FooBar _fooBarService;
    [SetUp]
    public void Setup()
    {
        _fooBarService = new FooBar();
        _fooBarService.RuleSetDict = new Dictionary<int, string>()
        {
            {3, "Foo"},
            {5, "Bar"},
            {7, "Jazz"},
            {9, "Huzz"}
        };
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(12)]
    [TestCase(24)]
    public void ModuloProcessor_Returns0001_WhenInputIs3(int input)
    {
        BitArray expected = new BitArray(new bool[] { true, false, false, false });
        BitArray result = _fooBarService.ModuloProcessor(input);
        Assert.That(result.Cast<bool>().SequenceEqual(expected.Cast<bool>()));
    }

    [TestCase(5)]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(25)]
    public void ModuloProcessor_Returns0010_WhenInputIs5(int input)
    {
        BitArray expected = new BitArray(new bool[] { false, true, false, false });
        BitArray result = _fooBarService.ModuloProcessor(input);
        Assert.That(result.Cast<bool>().SequenceEqual(expected.Cast<bool>()));
    }

    [TestCase(7)]
    [TestCase(14)]
    [TestCase(28)]
    [TestCase(49)]
    public void ModuloProcessor_Returns0100_WhenInputIs7(int input)
    {
        BitArray expected = new BitArray(new bool[] { false, false, true, false });
        BitArray result = _fooBarService.ModuloProcessor(input);
        Assert.That(result.Cast<bool>().SequenceEqual(expected.Cast<bool>()));
    }

    [TestCase(9)]
    [TestCase(18)]
    [TestCase(36)]
    [TestCase(72)]
    public void ModuloProcessor_Returns1000_WhenInputIs9(int input)
    {
        BitArray expected = new BitArray(new bool[] { false, false, false, true });
        BitArray result = _fooBarService.ModuloProcessor(input);
        Assert.That(result.Cast<bool>().SequenceEqual(expected.Cast<bool>()));
    }
}