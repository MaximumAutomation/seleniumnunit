using System;
using TechTalk.SpecFlow;

namespace ExternalProject
{
    [Binding]
    public class ExternalDefinition
    {
        [When(@"User clears text on textbox ""(.*)""")]
        public void WhenUserClearsTextOnTextbox(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
