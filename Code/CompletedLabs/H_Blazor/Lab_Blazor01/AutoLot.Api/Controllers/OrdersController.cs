// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - OrdersController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Api.Controllers;

public class OrdersController(IAppLogging<OrdersController> logger, IOrderRepo repo)
    : BaseCrudController<Order, OrdersController>(logger, repo);