// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - CreditRisksController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Api.Controllers;

public class CreditRisksController(IAppLogging<CreditRisksController> logger, ICreditRiskRepo repo)
    : BaseCrudController<CreditRisk, CreditRisksController>(logger, repo);