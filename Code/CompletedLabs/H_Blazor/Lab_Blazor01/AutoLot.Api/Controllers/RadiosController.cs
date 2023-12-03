﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - RadiosController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/1
// ==================================

namespace AutoLot.Api.Controllers;

public class RadiosController(IAppLogging<RadiosController> logger, IRadioRepo repo)
    : BaseCrudController<Radio, RadiosController>(logger, repo);