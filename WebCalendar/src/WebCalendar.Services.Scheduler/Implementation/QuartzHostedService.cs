﻿using System.Threading;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using WebCalendar.Services.Scheduler.Contracts;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Scheduler.Implementation
{
    public class QuartzHostedService : IQuartzHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
        }

        public IScheduler Scheduler { get; set; }

        async Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            await Scheduler.Start(cancellationToken);
            //using (var scope = _scopeFactory.CreateScope())
            //{
            //    var dataLoader = scope.ServiceProvider.GetRequiredService<ISchedulerDataLoader>();

            //    IEnumerable<SchedulerEvent> @events = await dataLoader.GetSchedulerEvents();
            //    IEnumerable<SchedulerReminder> reminders = await dataLoader.GetSchedulerReminders();
            //    IEnumerable<SchedulerTask> tasks = await dataLoader.GetSchedulerTasks();

            //    foreach (var @event in @events)
            //    {
            //        await Scheduler.ScheduleEvent(@event);
            //    }

            //    foreach (var reminder in reminders)
            //    {
            //        await Scheduler.ScheduleReminder(reminder);
            //    }

            //    foreach (var task in tasks)
            //    {
            //        await Scheduler.ScheduleTask(task);
            //    }
            //}
        }

        async Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }
    }
}