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
            Context.Reconciles.RemoveRange(Context.Reconciles);
            Context.SaveChanges();
        }

        [Fact]
        public void InsertAll() {
            InsertFiles();
            InsertProperties();
            InsertReconciles();
        }

        public void InsertFiles() {
            var range = Enumerable.Range(0, 100_000);
            var files = range.Select(x => new QFile {
                CreateDate = DateTime.Now,
                Status = Status.Initialize
            });

            Context.Files.AddRange(files);
            Context.SaveChanges();
        }

        public void InsertReconciles() {
            var files = Context.Files.ToList();
            var reconciles = files.Select(x => new QReconcile {
                Reference = x.Id.ToString("D10")
            });

            Context.Reconciles.AddRange(reconciles);
            Context.SaveChanges();
        }

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
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.Category.ToText(),
                        StringValue = "Category"
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.CustomerCode.ToText(),
                        StringValue = "CustomerCode"
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.CustomerName.ToText(),
                        StringValue = "CustomerName"
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.Department.ToText(),
                        StringValue = "Department"
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.DocumentDate.ToText(),
                        StringValue = DateTime.Now.ToString(),
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.DocumentType.ToText(),
                        StringValue = "DocumentType"
                    },
                    new QProperty {
                        QFileId = x.Id,
                        Name = CustomProperty.ExpireDate.ToText(),
                        StringValue = DateTime.Now.ToString()
                    }
                };
                return props;
            }).SelectMany(x => x);

            Context.Properties.AddRange(properties);
            Context.SaveChanges();
        }
    }
}
