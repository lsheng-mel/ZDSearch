using ZendeskSearch.Print;
using ZendeskSearch.Search;

namespace ZendeskSearchUnitTest.TestUnits
{
    public class SearchStepManagerForTest : SearchStepManager
    {
        public SearchStepManagerForTest(IUserInputPromptPrinter userInputPromptPrinter) : base(userInputPromptPrinter)
        {
        }

        protected override void PrintInvalidInputError()
        {
        }
    }
}