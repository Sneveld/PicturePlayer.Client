using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace PicturePlayer.Client.Model.UnitTest
{
    [TestClass]
    public class JsonParserTest
    {

        private string testJsonGood = @"
[
{'StartTime' : '00-00-00', 'Name' : 'John', 'Link' : '24'},
{'StartTime' : '00-00-00', 'Name' : 'John', 'Link' : '24'},
{'StartTime' : '00-00-00', 'Name' : 'John', 'Link' : '24'}
]";

        [TestMethod]
        public void JsonParser_Parse_InputGoodJsonSuccsess()
        {
            var jsonParse = new JsonParser();
            var res = jsonParse.Parse(testJsonGood);

        }

    }
}
