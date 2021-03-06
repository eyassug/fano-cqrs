﻿namespace Fano.CQRS.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using Fano.CQRS.Messaging;

    /// <summary>
    /// Base class for event sourced entities that implements <see cref="IEventSourced"/>. 
    /// </summary>
    /// <remarks>
    /// <see cref="IEventSourced"/> entities do not require the use of <see cref="EventSourced"/>, but this class contains some common 
    /// useful functionality related to versions and rehydration from past events.
    /// </remarks>
    public abstract class EventSourced<TKey> : IEventSourced<TKey>
    {
        private readonly Dictionary<Type, Action<IVersionedEvent>> handlers = new Dictionary<Type, Action<IVersionedEvent>>();
        private readonly List<IVersionedEvent> pendingEvents = new List<IVersionedEvent>();

        private readonly TKey id;
        private int version = -1;

        protected EventSourced(TKey id)
        {
            this.id = id;
            Handles<UnknownEvent>(this.On);
        }

        public TKey Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets the entity's version. As the entity is being updated and events being generated, the version is incremented.
        /// </summary>
        public int Version
        {
            get { return this.version; }
            protected set { this.version = value; }
        }

        /// <summary>
        /// Gets the collection of new events since the entity was loaded, as a consequence of command handling.
        /// </summary>
        public IEnumerable<IVersionedEvent> Events
        {
            get { return this.pendingEvents; }
        }

        /// <summary>
        /// Configures a handler for an event. 
        /// </summary>
        protected void Handles<TEvent>(Action<TEvent> handler)
            where TEvent : IEvent
        {
            this.handlers.Add(typeof(TEvent), @event => handler((TEvent)@event));
        }

        protected void LoadFrom(IEnumerable<IVersionedEvent> pastEvents)
        {
            foreach (var e in pastEvents)
            {
                this.handlers[e.GetType()].Invoke(e);
                // UnkownEvent should not alter Aggregate version
                if(e is UnknownEvent) continue;
                this.version = e.Version;
            }
        }

        protected void Update(VersionedEvent e)
        {
            e.SourceId = this.Id.ToString();
            e.Version = this.version + 1;
            this.handlers[e.GetType()].Invoke(e);
            this.version = e.Version;
            this.pendingEvents.Add(e);
        }

        protected void On(UnknownEvent @event)
        {
            // Do Nothing
        }
    }
}
