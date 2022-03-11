using MorseCode;
using NUnit.Framework;

[TestFixture]
public class PossibilitiesTest
{
    [Test]
    public void BasicCases()
    {
        Assert.AreEqual(new string[] { "E" }, Challenge.Possibilities("."));
        Assert.AreEqual(new string[] { "I" }, Challenge.Possibilities(".."));
        Assert.AreEqual(new string[] { "S" }, Challenge.Possibilities("..."));
        Assert.AreEqual(new string[] { "T" }, Challenge.Possibilities("-"));
        Assert.AreEqual(new string[] { "M" }, Challenge.Possibilities("--"));
        Assert.AreEqual(new string[] { "O" }, Challenge.Possibilities("---"));
        Assert.AreEqual(new string[] { "A" }, Challenge.Possibilities(".-"));
        Assert.AreEqual(new string[] { "R" }, Challenge.Possibilities(".-."));
        Assert.AreEqual(new string[] { "A" }, Challenge.Possibilities(".-"));
        Assert.AreEqual(new string[] { "E", "T" }, Challenge.Possibilities("?"));
        Assert.AreEqual(new string[] { "I", "N" }, Challenge.Possibilities("?."));
        Assert.AreEqual(new string[] { "I", "A" }, Challenge.Possibilities(".?"));
        Assert.AreEqual(new string[] { "U", "W" }, Challenge.Possibilities(".?-"));
        Assert.AreEqual(new string[] { "R", "W", "G", "O" }, Challenge.Possibilities("?-?"));
        Assert.AreEqual(new string[] { "I", "A", "N", "M" }, Challenge.Possibilities("??"));
        Assert.AreEqual(new string[] { "S", "U", "R", "W", "D", "K", "G", "O" }, Challenge.Possibilities("???"));
    }
}