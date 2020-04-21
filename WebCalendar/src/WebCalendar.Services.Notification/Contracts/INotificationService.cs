﻿using System;
using System.Threading.Tasks;
using WebCalendar.DAL.Models;
using WebCalendar.Services.Notification.Models;

namespace WebCalendar.Services.Notification.Contracts
{
    public interface INotificationService
    {
        Task SendTaskNotificationAsync(TaskNotificationServiceModel task, NotificationType type);
    }
}