using Xunit;
using System.Linq;

namespace MyApp {
    public class Query : TestBase {

        [Fact]
        public void Q() {
            var name = CustomProperty.Reference.ToText();
            var context = Context;
            var info =
                from file in context.Files
                join prop in context.Properties on file.Id equals prop.QFileId into props
                let value = file.Id.ToString("D10")
                let create = file.CreateDate.ToString("DD/MMM/yyyy")
                where props.Any(x => x.Name == name && x.StringValue == value)
                select new {
                    File = new {
                        Status = file.Status,
                        CreateDate = file.CreateDate
                    },
                    Props = props.Select(x => new {
                        Name = x.Name,
                        Value = x.StringValue
                    })
                };

            var rs = info.Take(9000).ToList();
            Assert.Equal(9000, rs.Count);
        }
    }
}