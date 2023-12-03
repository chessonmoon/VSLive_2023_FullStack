﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - CustomDbUpdateException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Dal.Exceptions;

public class CustomDbUpdateException : CustomException
{
    public CustomDbUpdateException()
    {
    }

    public CustomDbUpdateException(string message) : base(message)
    {
    }

    public CustomDbUpdateException(string message, DbUpdateException innerException)
        : base(message, innerException)
    {
    }
}
