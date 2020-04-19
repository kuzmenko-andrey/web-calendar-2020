﻿using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;
using WebCalendar.Services.Notification.Contracts;

namespace WebCalendar.Services.Scheduler.Implementation
{
    [DisallowConcurrentExecution]
    public class NotificationJob : IJob
    {
        private readonly ILogger<NotificationJob> _logger;
        private readonly INotificationService _notificationService;
        public static readonly string JobDataKey = "key1";
        public static readonly string JobActivityTypeKey = "key2";

        public NotificationJob(ILogger<NotificationJob> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap jobDataMap = context.JobDetail.JobDataMap;

            string value = jobDataMap.GetString(JobDataKey);
            _logger.LogInformation(value);
            
            
            return Task.CompletedTask;
        }
    }
}