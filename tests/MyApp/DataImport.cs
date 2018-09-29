using System;
using System.Linq;
using EasyValidator.Entity.Models;
using Xunit;

namespace MyApp {
    public class DataImport : TestBase {
        [Fact]
        public void CreateDb() {
            Context.Database.EnsureCreated();
        }

        [Fact]
        public void ClearDb() {
            Context.Properties.RemoveRange(Context.Properties);
            Context.Files.RemoveRange(Context.Files);
            Context.SaveChanges();
        }

        [Fact]
        public void InsertFiles() {
            var range = Enumerable.Range(0, 10000);
            var files = range.Select(x => new QFile {
                CreateDate = DateTime.Now,
                Status = Status.Initialize
            });

            Context.Files.AddRange(files);
            Context.SaveChanges();
        }

        [Fact]
        public void InsertCeconciles() {
            var files = Context.Files.ToList();
            var reconciles = files.Select(x => new QReconcile {
                Reference = "Reference" + x.Id
            });

            Context.Reconciles.AddRange(reconciles);
            Context.SaveChanges();
        }

        [Fact]
        public void InsertProperties() {
            var files = Context.Files.ToList();
            var properties = files.Select(x => {
                var props = new[] {
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.Reference.ToText(),
                        StringValue = x.Id.ToString("D10")
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.Site.ToText(),
                        StringValue = "Site"
                    }
                };
                return props;
            }).SelectMany(x => x);

            Context.Properties.AddRange(properties);
            Context.SaveChanges();
        }
    }
}
