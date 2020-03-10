﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCalendar.Common.Contracts;
using WebCalendar.DAL;
using WebCalendar.DAL.Models.Entities;
using WebCalendar.Services.Contracts;
using WebCalendar.Services.Models.Event;
using Task = System.Threading.Tasks.Task;

namespace WebCalendar.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public async Task AddAsync(EventCreationServiceModel entity)
        {
            Event @event = _mapper.Map<EventCreationServiceModel, Event>(entity);
            await _uow.GetRepository<Event>().AddAsync(@event);

            await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var events = await _uow.GetRepository<Event>()
                .GetAllAsync();

            return events;
        }

        public async Task<EventServiceModel> GetByIdAsync(Guid id)
        {
            var @event = await _uow.GetRepository<Event>()
                .GetByIdAsync(id);
            var eventServiceModel = _mapper.Map<Event, EventServiceModel>(@event);

            return eventServiceModel;
        }

        public async Task RemoveAsync(Guid id)
        {
            Event @event = await _uow.GetRepository<Event>()
                .GetByIdAsync(id);
            EventServiceModel eventServiceModel = _mapper
                .Map<Event, EventServiceModel>(@event);

            await RemoveAsync(eventServiceModel);
        }

        public async Task RemoveAsync(EventServiceModel entity)
        {
            Event @event = _mapper
                .Map<EventServiceModel, Event>(entity);
            _uow.GetRepository<Event>().Remove(@event);

            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(EventCreationServiceModel entity)
        {
            Event @event = _mapper
                .Map<EventCreationServiceModel, Event>(entity);
            _uow.GetRepository<Event>().Update(@event);

            await _uow.SaveChangesAsync();
        }
    }
}