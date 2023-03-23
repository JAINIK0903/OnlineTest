namespace OnlineTest.Models.Interfaces
{
    public interface ITestLinkRepository
    {
        IEnumerable<TestLink> GetTestLinks(Guid token);
        int AddTestLink(TestLink testlink);
        bool IsTestLinkExists(int testId, int userId);
        //int UpdateTestLink(TestLink testlink);

    } 
}