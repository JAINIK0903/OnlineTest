﻿namespace OnlineTest.Models.Interfaces
{
    public interface ITestLinkRepository
    {
        //TestLink GetTestLink();
        int AddTestLink(TestLink testLink);
        bool IsTestLinkExists(int testId, int userId);
        // bool UpdateTestLink(TestLink testLink);
    }
}