using Cities.Infrastructure.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cities.Tests
{
    public class TagHelperTests
    {
        [Fact]
        public void TestTagHelper()
        {
            //Przygotowanie.
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "myuniqueid");
            var output = new TagHelperOutput("button", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            //Dzia³anie.
            var tagHelper = new ButtonTagHelper
            {
                BsButtonColor = "wartoœæTestowa"
            };
            tagHelper.Process(context, output);

            //Asercje.
            Assert.Equal($"btn btn-{tagHelper.BsButtonColor}", output.Attributes["class"].Value);
        }
    }
}
