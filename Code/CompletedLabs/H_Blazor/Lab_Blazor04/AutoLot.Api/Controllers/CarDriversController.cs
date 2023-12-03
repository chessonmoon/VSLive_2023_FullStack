// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Api.Controllers;

public class CarDriversController(IAppLogging<CarDriversController> logger, ICarDriverRepo repo)
    : BaseCrudController<CarDriver, CarDriversController>(logger, repo);

