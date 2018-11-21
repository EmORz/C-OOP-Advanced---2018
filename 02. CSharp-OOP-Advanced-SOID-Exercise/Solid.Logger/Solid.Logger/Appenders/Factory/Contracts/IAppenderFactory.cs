﻿using System;
using System.Collections.Generic;
using System.Text;
using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Layouts.Contracts;

namespace Solid.Logger.Appenders.Factory.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
