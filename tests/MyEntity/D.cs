using EasyValidator.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class MyContextFactory : IDesignTimeDbContextFactory<EasyValidatorContext> {
    public EasyValidatorContext CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<EasyValidatorContext>();
        optionsBuilder.UseNpgsql("Host=localhost;User Id=postgres;Password=1234;Database=DDDD");

        return new EasyValidatorContext(optionsBuilder.Options);
    }
}