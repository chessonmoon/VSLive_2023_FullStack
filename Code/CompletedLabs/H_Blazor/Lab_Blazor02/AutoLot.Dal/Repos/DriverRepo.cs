// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - DriverRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Dal.Repos;

public class DriverRepo : TemporalTableBaseRepo<Driver>, IDriverRepo
{
    public DriverRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal DriverRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    internal IOrderedQueryable<Driver> BuildQuery()
        => Table.OrderBy(m => m.PersonInformation.LastName).ThenBy(f => f.PersonInformation.FirstName);

    public override IEnumerable<Driver> GetAll()
        => BuildQuery();

    public override IEnumerable<Driver> GetAllIgnoreQueryFilters()
        => BuildQuery().IgnoreQueryFilters();

}
