﻿using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Services.Models.Task;

namespace WebCalendar.Services.Contracts
{
    public interface ITaskService : IAsyncService<TaskServiceModel>
    {
    }
}
