using NUnit.Framework;
using SortColumnsOfCsvFile;

[TestFixture]
public class SortCsvColumnsTest
{

    [Test, Description("should handle the example")]
    public void ShouldHandleTheExample()
    {
        Assert.AreEqual(
                                     "Adam,Beth,Charles,Danielle,Eric\n3907,17945,10091,10088,10132\n48,2,12,13,11",
            Challenge.SortCsvColumns("Beth,Charles,Danielle,Adam,Eric\n17945,10091,10088,3907,10132\n2,12,13,48,11"));

        Assert.AreEqual(
                                     ",Adam,Beth,Charles,Eric\n10088,3907,17945,10091,10132\n13,48,2,12,11",
            Challenge.SortCsvColumns("Beth,Charles, ,Adam,Eric\n17945,10091,10088,3907,10132\n2,12,13,48,11"));

        Assert.AreEqual(
                                     ",Adam,Beth,Charles,Eric\n10088,3907,17945,10091,10132\n13,48,2,12,11",
            Challenge.SortCsvColumns("Beth,Charles,,Adam,Eric\n17945,10091,10088,3907,10132\n2,12,13,48,11"));
    }
}
