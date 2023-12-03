// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - DriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Api.Controllers;

public class DriversController(IAppLogging<DriversController> logger, IDriverRepo repo)
    : BaseCrudController<Driver, DriversController>(logger, repo);