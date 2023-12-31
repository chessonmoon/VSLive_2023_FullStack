﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Privacy.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoLot.Web.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

