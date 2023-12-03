// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - OrderRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Dal.Repos;

public class OrderRepo : TemporalTableBaseRepo<Order>, IOrderRepo
{
    public OrderRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal OrderRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

}
