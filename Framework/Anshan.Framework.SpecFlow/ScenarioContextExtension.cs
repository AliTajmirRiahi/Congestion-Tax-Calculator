using TechTalk.SpecFlow;

namespace Anshan.Framework.SpecFlow
{
    public static class ScenarioContextExtension
    {
        public static void AddValue(this ScenarioContext context, string name, object value)
        {
            context.Remove(name);
            context.Add(name, value);
        }
    }
}