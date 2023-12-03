// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - CustomersController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Api.Controllers;

public class CustomersController(IAppLogging<CustomersController> logger, ICustomerRepo repo)
    : BaseCrudController<Customer, CustomersController>(logger, repo);