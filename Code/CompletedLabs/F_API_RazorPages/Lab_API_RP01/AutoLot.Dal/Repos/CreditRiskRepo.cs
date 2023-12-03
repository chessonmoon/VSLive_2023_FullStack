// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - CreditRiskRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Dal.Repos;

public class CreditRiskRepo : TemporalTableBaseRepo<CreditRisk>, ICreditRiskRepo
{
    public CreditRiskRepo(ApplicationDbContext context) : base(context)
    {
    }

    internal CreditRiskRepo(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
